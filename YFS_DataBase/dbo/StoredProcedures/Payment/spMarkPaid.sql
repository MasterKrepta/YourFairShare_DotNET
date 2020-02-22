CREATE PROCEDURE [dbo].[spMarkPaid]
	@billId int
AS
begin
	update Bills
	set IsCurrent = 0
	where Id = @billId;
end