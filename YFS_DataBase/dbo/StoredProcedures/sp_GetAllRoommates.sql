CREATE PROCEDURE [dbo].[sp_GetAllRoommates]
	@param1 int = 0,
	@param2 int
AS
	SELECT *from dbo.Roommates
RETURN 0
