CREATE PROCEDURE [dbo].[sp_Memberships_Select_Members_By_MemberName]
	@MemberName nvarchar(100)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT MemberID, MemberName, IsAvailable, Email, PhoneNumber, Address, InsertedDate, UpdatedDate
	FROM dbo.Member
	WHERE MemberName like '%' + @MemberName + '%'

RETURN