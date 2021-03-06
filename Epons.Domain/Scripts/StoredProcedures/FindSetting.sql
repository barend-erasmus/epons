﻿CREATE PROCEDURE [EPONS_API].[FindSetting]
@name VARCHAR(255)
AS
SELECT * FROM [Admin].[Settings] WHERE [Name] = @name;

EXEC [Audit].[CreateLogEntry] '[EPONS_API].[FindSetting]', 'Executed'