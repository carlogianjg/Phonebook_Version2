IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'update_list')
	DROP PROCEDURE dbo.update_list
GO

	CREATE PROCEDURE dbo.update_list
	AS 
	BEGIN
			UPDATE ListOfContacts
			SET FirstName = 'FirstName',
				MiddleName = 'MiddleName',
				LastName = 'LastName',
				PhoneNumber = 'PhoneNumber',
				Gender = 'Gender'
			WHERE id = 'id';
	END
GO