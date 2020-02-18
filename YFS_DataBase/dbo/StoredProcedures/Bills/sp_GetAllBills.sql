CREATE PROCEDURE [dbo].[sp_GetAllBills]
	
AS
begin
	SELECT [Id], BillName, [Amount], [DueDate] from dbo.Bills
end
