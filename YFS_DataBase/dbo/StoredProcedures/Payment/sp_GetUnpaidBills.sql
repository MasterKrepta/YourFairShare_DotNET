CREATE PROCEDURE [dbo].[sp_GetUnpaidBills]
	
as
begin
	select b.BillName, r.FirstName, r.LastName, b.BillName, b.AmountDue, b.DueDate
	from Bills AS b
	join AssignedBill AS a ON a.bill = b.Id
	join Roommates AS r ON r.RoommateId = a.roommate

	where NOT EXISTS(select * from Payment where RoommateId = r.RoommateId)
end