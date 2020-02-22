CREATE PROCEDURE [dbo].[sp_AddPayment]
	@BillId int,
	@RoommateId int,
	@Amount decimal
AS
begin
		insert into dbo.Payment (BillId, RoommateId, AmountPaid, DatePaid)
						  values(@BillId, @RoommateId, @Amount, SYSDATETIME())
end