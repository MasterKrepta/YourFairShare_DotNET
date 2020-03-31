CREATE PROCEDURE [dbo].[sp_RemoveAssignedBill]
	@billId int,
	@roommateId int
AS
begin
	delete from AssignedBill
	where  bill = @billId AND roommate =  @roommateId;
end
