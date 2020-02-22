CREATE TABLE [dbo].[Bills]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[BillName] NVARCHAR(50) NOT NULL, 
	[AmountDue] MONEY NOT NULL, 
	[DueDate] DATETIME2 NOT NULL, 
    [IsCurrent] BIT NOT NULL DEFAULT 1
)
