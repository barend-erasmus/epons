CREATE PROCEDURE [EPONS_API].[FindPatientIdByIdentificationNumber] 
@identificationNumber VARCHAR(255)
AS
SELECT 
[patient].[PatientId] AS [Id] 
FROM [Patient].[Details] AS [patient]
WHERE [patient].[IdentificationNumber] = @identificationNumber

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindPatientIdByIdentificationNumber] ', 'Executed'
