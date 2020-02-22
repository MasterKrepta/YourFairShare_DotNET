CREATE PROCEDURE [dbo].[sp_ApplyPayment]
	@billId int,
	@newAmount money
AS
begin
	update Bills
	set AmountDue = @newAmount
	where Id = @billId;
end