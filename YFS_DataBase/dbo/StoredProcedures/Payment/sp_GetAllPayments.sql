﻿CREATE PROCEDURE [dbo].[sp_GetAllPayments]
	
AS
	select b.BillName, r.FirstName, r.LastName, b.BillName, b.AmountDue, b.DueDate
	from Bills AS b
	join AssignedBill AS a ON a.bill = b.Id
	join Roommates AS r ON r.RoommateId = a.roommate

	where EXISTS(select * from Payment where RoommateId = r.RoommateId)
RETURN 0
