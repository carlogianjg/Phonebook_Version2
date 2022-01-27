﻿IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ListOfContacts' )
BEGIN
		CREATE TABLE Contacts
		(
			id INT PRIMARY KEY IDENTITY NOT NULL,
			FirstName NVARCHAR (100),
			MiddleName NVARCHAR (100),
			LastName NVARCHAR (100),
			PhoneNumber NVARCHAR (50),
			Gender NVARCHAR (50),
		)

END
