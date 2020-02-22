CREATE PROCEDURE [dbo].[sp_GetAllBills]
	
AS
begin
	SELECT [Id], BillName, AmountDue, [DueDate], IsCurrent from dbo.Bills
end
