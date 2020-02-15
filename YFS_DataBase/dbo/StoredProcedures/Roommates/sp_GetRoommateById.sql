CREATE PROCEDURE [dbo].[sp_GetRoommateById]
	@roommateId int
AS
begin
	SELECT * from dbo.Roommates
	where RoommateId = @roommateId;
end
