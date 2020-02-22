CREATE PROCEDURE [dbo].[sp_AddNewBill]
	@BillName nvarchar(50),
	@Amount money,
	@DueDate datetime2(7)
AS
	begin
		insert into dbo.Bills (BillName, AmountDue, DueDate)
								values(@BillName, @Amount, @DueDate)
	end

