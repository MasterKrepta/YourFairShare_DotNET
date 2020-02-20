CREATE PROCEDURE [dbo].[sp_CalculatePayment]
	
AS
begin
	SELECT AmountDue from dbo.Bills
end
