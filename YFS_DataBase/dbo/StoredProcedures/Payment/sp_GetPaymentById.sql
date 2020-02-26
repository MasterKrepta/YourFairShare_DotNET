CREATE PROCEDURE [dbo].[sp_GetPaymentById]
	@paymentId int
AS
begin
	SELECT * from dbo.Payment
	where Id = @paymentId;
end
