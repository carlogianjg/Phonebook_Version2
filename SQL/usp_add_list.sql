IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'usp_add_list')
	DROP PROCEDURE dbo.usp_add_list
GO
	CREATE PROCEDURE dbo.usp_add_list
		@FirstName NVARCHAR(100) = NULL,
		@MiddleName NVARCHAR(100) = NULL,
		@LastName NVARCHAR(100) = NULL,
		@PhoneNumber NVARCHAR(50) = NULL,
		@Gender NVARCHAR(50) = NULL
	AS 
	BEGIN
		IF NOT EXISTS (SELECT * FROM ListOfContacts WHERE FirstName = @FirstName and 
		MiddleName = @MiddleName and LastName = @LastName and PhoneNumber = @PhoneNumber and Gender = @Gender)
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
	END
GO
