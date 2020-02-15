CREATE PROCEDURE [dbo].[sp_RemoveRoommate]
	@id int
AS
begin
	delete from dbo.Roommates
	where RoommateId = @id;
end
