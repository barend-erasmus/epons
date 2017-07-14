CREATE PROCEDURE [EPONS_API].[ListTreatingDoctorsByPatientId] 
@patientId UNIQUEIDENTIFIER
AS
SELECT 
[doctor].[Name] AS [Fullname],
[doctor].[ContactNumber] AS [ConactNumber],
[doctor].[Email] AS [EmailAddress],
[doctor].[HPCSANumber] AS [HPCSANumber],
[doctor].[PracticeName] AS [PracticeNumber],
[facility].[FacilityId] AS [FacilityId],
[facility].[Name] AS [FacilityName]
FROM [Patient].[EpisodesOfCare] AS [episodeOfCare]
INNER JOIN [Patient].[Doctor] AS [doctor]
ON [doctor].[Id] = [episodeOfCare].[AttendingDoctorId]
INNER JOIN [Facility].[Details] AS [facility]
ON [facility].[FacilityId] = [episodeOfCare].[FacilityId]
WHERE [episodeOfCare].[PatientId] = @patientId

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[ListTreatingDoctorsByPatientId]', 'Executed'