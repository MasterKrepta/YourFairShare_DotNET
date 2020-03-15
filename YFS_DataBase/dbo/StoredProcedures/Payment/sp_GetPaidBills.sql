CREATE PROCEDURE [dbo].[sp_GetPaidBills]
AS
	SELECT * from Bills
	where Bills.IsCurrent = 0
RETURN 0



