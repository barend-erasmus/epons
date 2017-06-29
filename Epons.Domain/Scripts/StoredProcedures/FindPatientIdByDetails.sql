CREATE PROCEDURE [EPONS_API].[FindPatientIdByDetails] 
@firstname VARCHAR(255),
@lastname VARCHAR(255),
@dateOfBirth DATE
AS
SELECT 
[patient].[PatientId] AS [Id] 
FROM [Patient].[Details] AS [patient]
WHERE [patient].[Firstname] = @firstname
AND [patient].[Lastname] = @lastname
AND [patient].[DateOfBirth] = @dateOfBirth

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindPatientIdByDetails]', 'Executed'
