CREATE PROCEDURE [EPONS_API].[FindCompletedMeasurementToolsByPatientIdAndDateRange] 
@patientId UNIQUEIDENTIFIER,
@startDate DATE,
@endDate DATE
AS
CREATE TABLE #completedMeasurementTool (
	[DataSetId] UNIQUEIDENTIFIER NOT NULL,
	[MeasurementToolId] UNIQUEIDENTIFIER NOT NULL,
	[ScoreItemId] UNIQUEIDENTIFIER NOT NULL,
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NULL,
	[IsCompleted] BIT NOT NULL,
	[MeasurementTool] VARCHAR(255),
	[ScoreItem] VARCHAR(255),
	[ScoreItemSortOrder] INT,
	[ScoreValue] INT
)

SELECT
[visit].[VisitId] AS [Id],
[visit].[Timestamp] AS [Timestamp],
[measurementTool].[MeasurementToolId] AS [MeasurementToolId],
[scoreItem].[ScoreItemId] AS [ScoreItemId],
0 AS [Processed],
[measurementTool].[Name] AS [MeasurementTool],
[scoreItem].[Name] AS [ScoreItem],
[scoreItem].[SortOrder] AS [ScoreItemSortOrder],
[scoreValue].[Value] AS [ScoreValue]
INTO #visits 
FROM [Visit].[Details] AS [visit]
INNER JOIN [Visit].[ScoreValues] AS [visitScore]
ON 
[visit].[PatientId] = @patientId
AND
CONVERT(DATE, [visit].[Timestamp]) >= @startDate 
AND
CONVERT(DATE, [visit].[Timestamp]) <= @endDate
AND
[visitScore].[VisitId] = [visit].[VisitId]
INNER JOIN [ValueObjects].[ScoreValues] AS [scoreValue]
ON [scoreValue].[ScoreValueId] = [visitScore].[ScoreValueId]
INNER JOIN [ValueObjects].[ScoreItems] AS [scoreItem]
ON [scoreItem].[ScoreItemId] = [scoreValue].[ScoreItemId]
AND
[scoreItem].[ParentScoreItemId] IS NULL
INNER JOIN [ValueObjects].[MeasurementTools] AS [measurementTool]
ON [measurementTool].[MeasurementToolId] = [scoreItem].[MeasurementToolId]
ORDER BY [Timestamp] ASC

DECLARE @currentMeasurementToolId UNIQUEIDENTIFIER
DECLARE @currentVisitId UNIQUEIDENTIFIER
DECLARE @currentDataSetId UNIQUEIDENTIFIER
DECLARE @currentVisitTimestamp DATETIME
DECLARE @currentScoreItemId UNIQUEIDENTIFIER
DECLARE @currentScoreItem VARCHAR(255)
DECLARE @currentScoreItemSortOrder INT
DECLARE @currentMeasurementTool VARCHAR(255)
DECLARE @currentScoreValue INT
DECLARE @scoreItemCount INT


WHILE (SELECT COUNT(*) FROM #visits WHERE [Processed] = 0) != 0
	BEGIN

		SELECT TOP 1 @currentVisitId = [Id],
		@currentVisitTimestamp = [Timestamp],
		@currentMeasurementToolId = [MeasurementToolId],
		@currentScoreItemId = [ScoreItemId],
		@currentMeasurementTool = [MeasurementTool],
		@currentScoreItem = [ScoreItem],
		@currentScoreItemSortOrder = [ScoreItemSortOrder],
		@currentScoreValue = CAST([ScoreValue] AS INT)
		FROM #visits WHERE [Processed] = 0 ORDER BY [Timestamp] ASC

		SET @currentDataSetId = NULL
		SELECT TOP 1 @currentDataSetId = [DataSetId]
		FROM #completedMeasurementTool 
		WHERE [IsCompleted] = 0 
		AND [MeasurementToolId] = @currentMeasurementToolId

		IF @currentDataSetId IS NULL
			SET @currentDataSetId = NEWID()

		INSERT INTO #completedMeasurementTool ([DataSetId], [MeasurementToolId], [ScoreItemId], [StartDate], [IsCompleted], [MeasurementTool], [ScoreItem], [ScoreItemSortOrder], [ScoreValue]) 
		VALUES (@currentDataSetId, @currentMeasurementToolId, @currentScoreItemId, @currentVisitTimestamp, 0, @currentMeasurementTool, @currentScoreItem, @currentScoreItemSortOrder, @currentScoreValue)

		 SELECT @scoreItemCount = COUNT(*) FROM [ValueObjects].[ScoreItems] WHERE [MeasurementToolId] = @currentMeasurementToolId AND [ParentScoreItemId] IS NULL
		 
		 IF (SELECT  COUNT(DISTINCT [ScoreItemId]) FROM #completedMeasurementTool WHERE [IsCompleted] = 0 AND [DataSetId] = @currentDataSetId) = @scoreItemCount
			UPDATE #completedMeasurementTool SET [IsCompleted] = 1, [EndDate] = @currentVisitTimestamp WHERE [DataSetId] = @currentDataSetId
	

		UPDATE #visits SET [Processed] = 1 WHERE Id = @currentVisitId AND ScoreItemId = @currentScoreItemId

	END

SELECT [DataSetId], [MeasurementToolId], [MeasurementTool], [ScoreItem], [ScoreItemSortOrder], MIN([ScoreValue]) AS [ScoreValue], MIN([StartDate]) AS [StartDate], MAX(EndDate) AS [EndDate]
FROM #completedMeasurementTool 
WHERE [IsCompleted] = 1 
GROUP BY [DataSetId], [MeasurementToolId], [MeasurementTool], [ScoreItem], [ScoreItemSortOrder]
ORDER BY [DataSetId] ASC

DROP TABLE #completedMeasurementTool
DROP TABLE #visits

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindCompletedMeasurementToolsByPatientIdAndDateRange]', 'Executed'