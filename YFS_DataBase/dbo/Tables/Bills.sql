﻿CREATE TABLE [dbo].[Bills]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[Name] NVARCHAR(50) NOT NULL, 
	[Amount] NVARCHAR(50) NOT NULL, 
	[DueDate] NVARCHAR(50) NOT NULL
)
