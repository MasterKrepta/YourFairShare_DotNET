CREATE PROCEDURE [dbo].[sp_UpdateRoommate]
	@RoommateId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
	begin
	update dbo.Roommates
	set FirstName = @FirstName, LastName = @LastName
	where [RoommateId] = @RoommateId
	
	end

