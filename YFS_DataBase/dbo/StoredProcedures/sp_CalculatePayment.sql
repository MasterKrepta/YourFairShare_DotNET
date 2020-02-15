CREATE PROCEDURE [dbo].[sp_CalculatePayment]
	
AS
begin
	SELECT [Amount] from dbo.Bills
end
