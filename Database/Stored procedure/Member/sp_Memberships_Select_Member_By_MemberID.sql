CREATE PROCEDURE [dbo].[sp_Memberships_Select_Member_By_MemberID]
	@MemberID int
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT MemberID, MemberName, IsAvailable, Email, PhoneNumber, Address, InsertedDate, UpdatedDate
	FROM dbo.Member
	WHERE MemberID = @MemberID

RETURN