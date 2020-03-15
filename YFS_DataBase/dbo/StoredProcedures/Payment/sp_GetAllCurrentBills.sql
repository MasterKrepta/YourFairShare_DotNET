CREATE PROCEDURE [dbo].[sp_GetAllCurrentBills]
AS
	SELECT * from Bills
	where Bills.IsCurrent = 1
RETURN 0
