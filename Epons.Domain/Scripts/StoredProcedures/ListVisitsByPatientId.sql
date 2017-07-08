SELECT
[visit].[VisitId] AS [Id],
[visit].[DailyNotes] AS [DailyNotes],
[visit].[DurationofVisitinMinutes] AS [Duration],
[visit].[ProgressNotes] AS [ProgressNotes],
[visit].[Timestamp] AS [Timestamp],
[user].[UserId] AS [UserId],
[user].[Firstname] + ' ' + [user].[Lastname] AS [Fullname]
INTO #temp
FROM [Visit].[Details] AS [visit]
INNER JOIN [User].[Details] AS [user]
ON [user].[UserId] = [visit].[UserId]
WHERE [visit].[PatientId] = '1130D8C7-959B-4DD6-BE67-C66A240F36BE'

SELECT * FROM #temp;

SELECT 
[visit].[Id] AS [Id],
[measurementTool].[MeasurementToolId] AS [Id],
[measurementTool].[Name] AS [Name]
FROM #temp AS [visit]
INNER JOIN [Visit].[ScoreValues] AS [visitScoreValue]
ON [visitScoreValue].[VisitId] = [visit].[Id]
INNER JOIN [ValueObjects].[ScoreValues] AS [scoreValue]
ON [scoreValue].[ScoreValueId] = [visitScoreValue].[ScoreValueId]
INNER JOIN [ValueObjects].[ScoreItems] AS [scoreItem]
ON [scoreItem].[ScoreItemId] = [scoreValue].[ScoreItemId]
INNER JOIN [ValueObjects].[MeasurementTools] AS [measurementTool]
ON [measurementTool].[MeasurementToolId] = [scoreItem].[MeasurementToolId]


SELECT DISTINCT
[visit].[UserId] AS [UserId],
[facility].[FacilityId] AS [FacilityId],
[facility].[Name] AS [Facility],
[permission].[PermissionId] AS [PermissionId],
[permission].[Name] AS [Permission]
FROM #temp AS [visit]
INNER JOIN [User].[Permissions] AS [userPermission]
ON [userPermission].[UserId] = [visit].[UserId]
INNER JOIN [Facility].[Details] AS [facility]
ON [facility].[FacilityId] = [userPermission].[FacilityId]
INNER JOIN [ValueObjects].[Permissions] as [permission]
ON [permission].[PermissionId] = [userPermission].[PermissionId];


DROP TABLE #temp;
