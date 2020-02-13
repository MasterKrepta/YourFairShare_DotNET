CREATE PROCEDURE [dbo].[sp_GetAllRoommates]
	
AS
begin
	SELECT [FirstName], [LastName]from dbo.Roommates
end
