CREATE PROCEDURE [dbo].[sp_GetAllBills]
	
AS
begin
	SELECT [Id], BillName, AmountDue, [DueDate] from dbo.Bills
end
