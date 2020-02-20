CREATE PROCEDURE [dbo].[sp_AddPayment]
	@Date datetime2(7),
	@Amount decimal
AS
begin
		insert into dbo.Payment values(@Date, @Amount)
	end