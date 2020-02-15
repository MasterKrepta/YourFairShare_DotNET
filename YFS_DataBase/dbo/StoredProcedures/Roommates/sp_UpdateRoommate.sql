CREATE PROCEDURE [dbo].[sp_UpdateRoommate]
	@RoommateId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@MonthlyPayment decimal
AS
	begin
	update dbo.Roommates
	set FirstName = @FirstName, LastName = @LastName, MonthlyPayment = @MonthlyPayment
	where [RoommateId] = @RoommateId
	
	end

