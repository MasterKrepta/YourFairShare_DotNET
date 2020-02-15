CREATE PROCEDURE [dbo].[sp_AddNewBill]
	@Name nvarchar(50),
	@Amount money,
	@DueDate datetime2(7)
AS
	begin
		insert into dbo.Bills values(@Name, @Amount, @DueDate)
	end

