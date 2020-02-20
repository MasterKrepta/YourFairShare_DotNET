CREATE PROCEDURE [dbo].[sp_GetAllPayments]
	
AS
	SELECT [Id], [DatePaid], [AmountPaid] from dbo.Payment
RETURN 0
