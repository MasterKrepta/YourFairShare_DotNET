CREATE PROCEDURE [dbo].[sp_GetAllBills]
	
AS
begin
	SELECT [Id], [Name], [Amount], [DueDate] from dbo.Bills
end
