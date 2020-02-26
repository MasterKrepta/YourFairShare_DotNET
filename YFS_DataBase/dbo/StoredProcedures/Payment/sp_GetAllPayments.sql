CREATE PROCEDURE [dbo].[sp_GetAllPayments]
	
AS
	SELECT [Id], [DatePaid], [AmountPaid], [BillId], [RoommateId] from dbo.Payment
RETURN 0
