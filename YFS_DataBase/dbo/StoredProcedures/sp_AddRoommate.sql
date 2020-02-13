CREATE PROCEDURE [dbo].[sp_AddRoommate]
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin
Insert into dbo.Roommates 
						values(@FirstName, @LastName)
end
