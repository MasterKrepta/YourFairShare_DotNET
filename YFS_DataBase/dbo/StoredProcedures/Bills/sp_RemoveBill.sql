CREATE PROCEDURE [dbo].[sp_RemoveBill]
	@Name nvarchar(50)
AS
begin
	delete from dbo.Bills
	where Name = @Name;
end
