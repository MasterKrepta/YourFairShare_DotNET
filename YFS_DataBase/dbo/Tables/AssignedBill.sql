CREATE TABLE [dbo].[AssignedBill]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
	[roommate] INT NOT NULL,
	[bill] int not null, 
	CONSTRAINT [FK_AssignedBill_ToBill] FOREIGN KEY (bill) REFERENCES Bills(id), 
	

	

)
