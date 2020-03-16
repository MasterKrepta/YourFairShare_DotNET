CREATE PROCEDURE [dbo].[sp_GetAllBills]
	
AS
begin
	SELECT [Id], BillName, AmountDue, [DueDate], IsCurrent from dbo.Bills
	where IsCurrent = 1;
end
