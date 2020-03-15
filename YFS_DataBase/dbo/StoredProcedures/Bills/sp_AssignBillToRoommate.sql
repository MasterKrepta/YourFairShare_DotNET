CREATE PROCEDURE [dbo].[sp_AssignBillToRoommate]
	@BillId int,
	@RoommateId int
	
AS
	insert into AssignedBill(bill, roommate)
				Values(@BillId, @RoommateId)
RETURN 0
