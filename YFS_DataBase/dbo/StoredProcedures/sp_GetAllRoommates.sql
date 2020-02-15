CREATE PROCEDURE [dbo].[sp_GetAllRoommates]
	
AS
begin
	SELECT [FirstName], [LastName], [MonthlyPayment]from dbo.Roommates
end
