IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'usp_delete_list')
	DROP PROCEDURE dbo.usp_delete_list
GO

	CREATE PROCEDURE dbo.usp_delete_list
			@_id INT
	AS 
	BEGIN
			DELETE FROM ListOfContacts
			WHERE _id = @_id
	END
GO	
	