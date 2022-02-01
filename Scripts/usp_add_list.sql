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
		IF NOT EXISTS (SELECT * FROM ListOfContacts WHERE First_Name = @First_Name and 
		Middle_Name = @Middle_Name and Last_Name = @Last_Name and Phone_Number = @Phone_Number and _Gender = @_Gender)
			BEGIN
				SET NOCOUNT ON
				INSERT INTO dbo.ListOfContacts
				(
					First_Name,
					Middle_NAme,
					Last_Name,
					Phone_Number,
					_Gender
				)
				VALUES 
				(
					@First_Name,
					@Middle_Name,
					@Last_Name,
					@Phone_Number,
					@_Gender
				)
			END
	END
GO
