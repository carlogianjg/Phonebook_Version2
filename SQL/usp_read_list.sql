IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'usp_read_list')
	DROP PROCEDURE dbo.usp_read_list
GO

	CREATE PROCEDURE dbo.usp_read_list
	AS 
	BEGIN
			SELECT * FROM ListOfContacts
	END
GO