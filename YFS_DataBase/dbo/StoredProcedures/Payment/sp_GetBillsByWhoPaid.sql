CREATE PROCEDURE [dbo].[sp_GetBillsByWhoPaid]
	
as
begin
	select Payment.Id, BillName, BillId, RoommateId, AmountPaid, AmountDue from Bills

	inner join Payment on Payment.BillId = Bills.Id

end