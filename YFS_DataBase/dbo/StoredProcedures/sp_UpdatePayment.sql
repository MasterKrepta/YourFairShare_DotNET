CREATE PROCEDURE [dbo].[sp_UpdatePayment]
	@newPayment money
AS
begin
	update dbo.Roommates
	set MonthlyPayment = @newPayment
end
