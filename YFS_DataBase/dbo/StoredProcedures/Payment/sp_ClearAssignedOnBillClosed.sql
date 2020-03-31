CREATE PROCEDURE [dbo].[sp_ClearAssignedOnBillClosed]
	@billId int
	
AS
begin
	delete from AssignedBill
	where  bill = @billId;
end

