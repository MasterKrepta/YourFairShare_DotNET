CREATE PROCEDURE [dbo].[sp_RemoveBill]
	@id int
AS
begin
	delete from dbo.Bills
	where Id = @id;
end
