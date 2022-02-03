IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'list')
	DROP PROCEDURE dbo.usp_update_list
GO

	CREATE PROCEDURE dbo.usp_update_list
		@_id INT,
		@First_Name NVARCHAR(100), 
		@Middle_Name NVARCHAR(100), 
		@Last_Name NVARCHAR(100),
		@Phone_Number NVARCHAR(50), 
		@_Gender NVARCHAR(50) 
	AS
	BEGIN
		IF NOT EXISTS (SELECT * FROM ListOfContacts WHERE First_Name = @First_Name and 
		Middle_Name = @Middle_Name and Last_Name = @Last_Name and Phone_Number = @Phone_Number and Gender = @_Gender)
			BEGIN
					UPDATE ListOfContacts
					SET First_Name = @First_Name,
						Middle_Name = @Middle_Name,
						Last_Name = @Last_Name,
						Phone_Number = @Phone_Number,
						Gender = @_Gender
					WHERE _id = @_id;
			END
	END
GO