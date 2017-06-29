CREATE PROCEDURE [EPONS_API].[ListActivePatients] 
@start INT,
@length INT,
@userId UNIQUEIDENTIFIER,
@facilityId UNIQUEIDENTIFIER,
@query VARCHAR(255)
AS

SELECT
[patient].[PatientId] AS [Id],
[patient].[Firstname] AS [Firstname],
[patient].[Lastname] AS [Lastname],
[patient].[DateOfBirth] AS [DateOfBirth],
[patient].[IdentificationNumber] AS [IdentificationNumber],
[patient].[GenderId] AS [GenderId],
[gender].[Name] AS [Gender],
[patient].[RaceId] AS [RaceId],
[race].[Name] AS [Race],
[patient].[TitleId] AS [TitleId],
[title].[Name] AS [Title],
[medicalScheme].[MedicalSchemeId] AS [MedicalSchemeId],
[medicalScheme].[Name] AS [MedicalScheme],
[patient].[MedicalSchemeMembershipNumber] AS [MedicalSchemeNumber]
INTO #patientResultSet
FROM [Patient].[Details] AS [patient]
LEFT JOIN [ValueObjects].[Genders] AS [gender]
ON [gender].[GenderId] = [patient].[GenderId]
LEFT JOIN [ValueObjects].[Races] AS [race]
ON [race].[RaceId] = [patient].[RaceId]
LEFT JOIN [ValueObjects].[Titles] AS [title]
ON [title].[TitleId] = [patient].[TitleId]
LEFT JOIN [ValueObjects].[MedicalSchemes] AS [medicalScheme]
ON [medicalScheme].[MedicalSchemeId] = [patient].[MedicalSchemeId]
LEFT JOIN [ValueObjects].[ImpairmentGroups] AS [impairmentGroup]
ON [impairmentGroup].[ImpairmentGroupId] = [patient].[ImpairmentGroupId] 
WHERE
(
	@facilityId IS NULL
	AND
	(
		@query IS NULL
		OR 
		(
		SELECT COUNT(*)
		FROM [EPONS].[SplitString](@query, ' ')
		WHERE [patient].[Firstname] LIKE '%' + [Item] + '%'
		OR
		[patient].[Lastname] LIKE '%' + [Item] + '%'
		OR
		[patient].[IdentificationNumber] LIKE '%' + [Item] + '%'
	) > 0
	)
)
OR
(
	SELECT COUNT(*) 
	FROM [Patient].[TeamMembers] 
	WHERE [PatientId] = [patient].[PatientId]
	AND [FacilityId] = @facilityId
	AND 
	(
		(
			[DeallocationTimestamp] IS NULL
			AND 
			[UserId] = @userId
		)
		OR
		(
			@userId IS NULL
			AND 
			[DeallocationTimestamp] IS NULL
		)
	)
) > 0
AND
(
	[impairmentGroup].[Name] IS NULL
	OR
	[impairmentGroup].[Name] != 'Death - Death'	
)
AND
(
	@query IS NULL
	OR 
	(
		SELECT COUNT(*)
		FROM [EPONS].[SplitString](@query, ' ')
		WHERE [patient].[Firstname] LIKE '%' + [Item] + '%'
		OR
		[patient].[Lastname] LIKE '%' + [Item] + '%'
		OR
		[patient].[IdentificationNumber] LIKE '%' + [Item] + '%'
	) > 0
)


SELECT * FROM #patientResultSet ORDER BY [Lastname] OFFSET (@start) ROWS FETCH NEXT (@length) ROWS ONLY

SELECT DISTINCT
[teamMember].[PatientId] AS [PatientId],
[teamMember].[FacilityId] AS [FacilityId],
[facility].[Name] AS [FacilityName]
FROM [Patient].[TeamMembers] AS [teamMember]
INNER JOIN [Facility].[Details] AS [facility]
ON [facility].[FacilityId] = [teamMember].[FacilityId]

SELECT COUNT(*) AS [Count] FROM #patientResultSet


DROP TABLE #patientResultSet

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[ListActivePatients]', 'Executed'