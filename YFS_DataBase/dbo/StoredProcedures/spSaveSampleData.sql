CREATE PROCEDURE [dbo].[spSaveSampleData]
	@firstName nvarchar(50),
	@lastName nvarchar(50)
AS
begin
set nocount on;
	insert into dbo.Roommates(FirstName, LastName)
	values(@firstName, @lastName)
end
go
