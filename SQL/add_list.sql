IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'add_list')
	DROP PROCEDURE dbo.add_list
GO
	CREATE PROCEDURE dbo.add_list
		@FirstName NVARCHAR(100) = NULL,
		@MiddleName NVARCHAR(100) = NULL,
		@LastName NVARCHAR(100) = NULL,
		@PhoneNumber NVARCHAR(50) = NULL,
		@Gender NVARCHAR(50) = NULL
	AS 
	BEGIN
		SET NOCOUNT ON
		INSERT INTO dbo.ListOfContacts
		(
			FirstName,
			MiddleNAme,
			LastName,
			PhoneNumber,
			Gender
		)
		VALUES 
		(
			@FirstName,
			@MiddleName,
			@LastName,
			@PhoneNumber,
			@Gender
		)
	END
GO
