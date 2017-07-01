CREATE PROCEDURE [EPONS_API].[ListSupportServicesByPatientId] 
@patientId UNIQUEIDENTIFIER
AS
SELECT 
[patientSupportService].[SupportServiceId] AS [Id],
[supportService].[Name] AS [Name],
[patientSupportService].[Text] AS [Text]
FROM [Patient].[SupportServices] AS [patientSupportService]
INNER JOIN [ValueObjects].[SupportServices] AS [supportService]
ON [patientSupportService].[PatientId] = @patientId
AND
[supportService].[SupportServiceId] = [patientSupportService].[SupportServiceId]

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[ListSupportServicesByPatientId]', 'Executed'
