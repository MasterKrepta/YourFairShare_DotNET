CREATE PROCEDURE [dbo].[sp_GetAllBills]
	@param1 int = 0,
	@param2 int
AS
	SELECT * from dbo.Bills
RETURN 0
