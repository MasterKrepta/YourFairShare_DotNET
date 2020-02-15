CREATE PROCEDURE [dbo].[sp_GetAllRoommates]
	
AS
begin
	SELECT [RoommateId], [FirstName], [LastName], [MonthlyPayment]from dbo.Roommates
end
