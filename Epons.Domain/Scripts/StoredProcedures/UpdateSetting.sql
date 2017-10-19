CREATE PROCEDURE [EPONS_API].[UpdateSetting]
@name VARCHAR(255),
@value VARCHAR(255)
AS

UPDATE [Admin].[Settings] SET [Value]=@value WHERE [Name]=@name;

IF @@ROWCOUNT = 0
   INSERT INTO [Admin].[Settings] ([Name], [Value]) VALUES (@name, @value);

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[UpdateSetting]', 'Executed'