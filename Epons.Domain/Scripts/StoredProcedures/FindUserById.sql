
CREATE PROCEDURE [EPONS_API].[FindUserById] 
@userId UNIQUEIDENTIFIER
AS
SELECT 
[user].[UserId] AS [Id],
[credentials].[Username] AS [Username],
[user].[EmailAddress] AS [EmailAddress],
[user].[Firstname] AS [Firstname],
[user].[Lastname] AS [Lastname],
[user].[ContactNumber] AS [ContactNumber],
[user].[IdentificationNumber] AS [IdentificationNumber],
[user].[RegistrationNumber] AS [ProfessionalBodyRegistrationNumber],
[user].[PracticeNumber] AS [PracticeNumber],
[user].[TitleId] AS [TitleId],
[title].[Name] AS [Title],
[user].[ProfessionalBodyId] AS [ProfessionalBodyId],
[professionalBody].[Name] AS [ProfessionalBody],
[user].[currentPositionId] AS [PositionId],
[Position].[Name] AS [Position],
[user].[IsSuperAdmin] AS [IsSuperAdmin]
FROM [User].[Details]  AS [user] 
INNER JOIN [User].[Credentials] AS [credentials]
ON [credentials].[UserId] = [user].[UserId]
LEFT JOIN [ValueObjects].[Titles] AS [title]
ON [title].[TitleId] = [user].[TitleId]
LEFT JOIN [ValueObjects].[ProfessionalBodies] AS [professionalBody]
ON [professionalBody].[ProfessionalBodyId] = [user].[ProfessionalBodyId]
LEFT JOIN [ValueObjects].[Positions] AS [Position]
ON [position].PositionId = [user].[CurrentPositionId]
WHERE [user].[UserId] = @userId

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindUserById]', 'Executed'