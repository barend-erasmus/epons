CREATE PROCEDURE [EPONS_API].[ListPermissionsByUserId] 
@userId UNIQUEIDENTIFIER
AS
SELECT
[facility].[FacilityId] AS [FacilityId],
[facility].[Name] AS [Facility],
[permission].[PermissionId] AS [PermissionId],
[permission].[Name] AS [Permission]
FROM [User].[Permissions] AS [userPermission]
INNER JOIN [Facility].[Details] AS [facility]
ON [facility].[FacilityId] = [userPermission].[FacilityId]
INNER JOIN [ValueObjects].[Permissions] as [permission]
ON [permission].[PermissionId] = [userPermission].[PermissionId]
WHERE [userPermission].[UserId] = @userId

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[ListPermissionsByUserId]', 'Executed'