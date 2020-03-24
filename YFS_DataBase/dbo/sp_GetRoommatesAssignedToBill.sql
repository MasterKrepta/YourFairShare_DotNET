CREATE PROCEDURE [dbo].[sp_GetRoommatesAssignedToBill]

AS
	select b.BillName, r.RoommateId, r.FirstName, r.LastName 
	from Roommates As r
	join AssignedBill AS a ON a.roommate = r.RoommateId
	join Bills AS b On b.id = a.bill

	--select b.BillName, r.FirstName, r.LastName, b.BillName, b.AmountDue, b.DueDate
	--from Bills AS b
	--join AssignedBill AS a ON a.bill = b.Id
	--join Roommates AS r ON r.RoommateId = a.roommate

	--where NOT EXISTS(select * from Payment where RoommateId = r.RoommateId)

RETURN 0
