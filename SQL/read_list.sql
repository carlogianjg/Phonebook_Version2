﻿IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'read_list')
	DROP PROCEDURE dbo.read_list
GO

	CREATE PROCEDURE dbo.read_list
	AS 
	BEGIN
			SELECT * FROM ListOfContacts
	END
GO