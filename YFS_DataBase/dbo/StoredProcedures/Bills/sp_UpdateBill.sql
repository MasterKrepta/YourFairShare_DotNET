CREATE PROCEDURE [dbo].[sp_UpdateBill]
	@name nvarchar(50),
	@amount decimal,
	@dueDate datetime2(7)
AS
begin
	update Bills
	set AmountDue = @amount, DueDate = @dueDate
	where [BillName] = @name

end
