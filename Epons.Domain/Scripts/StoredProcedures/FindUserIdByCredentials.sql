CREATE PROCEDURE [EPONS_API].[FindUserIdByCredentials] 
@username VARCHAR(255),
@password VARCHAR(255)
AS
SELECT 
[userCredentials].[UserId] AS [Id]
FROM [User].[Credentials] AS [userCredentials]
INNER JOIN  [User].[Details] AS [userDetails]
ON [userDetails].[UserId] = [userCredentials].[UserId]
AND
[userCredentials].[Username] = @username
AND [userCredentials].[Password] = @password
AND [userCredentials].[Locked] = 0

UPDATE [User].[Credentials]
SET [LastLoginTimestamp] = GETDATE()
WHERE [Username] = @username
AND [Password] = @password

UPDATE [User].[Credentials]
SET [InvalidLoginAttempts] = [InvalidLoginAttempts] + 1
WHERE [Username] = @username
AND [Password] != @password

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindUserIdByCredentials]', 'Executed'