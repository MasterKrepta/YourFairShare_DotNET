CREATE TABLE [dbo].[Payment]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[DatePaid] DATETIME2 NOT NULL, 
	[AmountPaid] MONEY NOT NULL, 
	CONSTRAINT [FK_Payment_ToRoommate] FOREIGN KEY (Id) REFERENCES Roommates(RoommateId), 
	CONSTRAINT [FK_Payment_ToBills] FOREIGN KEY (Id) REFERENCES Bills(Id)
)
