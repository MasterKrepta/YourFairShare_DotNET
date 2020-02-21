CREATE PROCEDURE [dbo].[sp_GetBillById]
	@Id int
AS
begin
	SELECT * from dbo.Bills 
	where Id = @id;
end
