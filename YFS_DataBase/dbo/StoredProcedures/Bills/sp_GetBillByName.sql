CREATE PROCEDURE [dbo].[sp_GetBillByName]
	@Name nvarchar(50)
	
AS
begin
	SELECT * from dbo.Bills
	where BillName = @Name;
end
