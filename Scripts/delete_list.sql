IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'delete_list')
	DROP PROCEDURE dbo.delete_list
GO

	CREATE PROCEDURE dbo.delete_list
	AS 
	BEGIN
			DELETE FROM ListOfContacts
			WHERE id = 'id'
	END
GO	
	