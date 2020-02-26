CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[DatePaid] DATETIME2 NOT NULL, 
	[AmountPaid] MONEY NOT NULL, 
	[BillId] INT NOT NULL, 
	[RoommateId] INT NOT NULL, 

)
