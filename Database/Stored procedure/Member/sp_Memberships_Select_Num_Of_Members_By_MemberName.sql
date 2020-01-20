CREATE PROCEDURE [dbo].[sp_Memberships_Select_Num_Of_Members_By_MemberName]
	@MemberName nvarchar(100)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT COUNT(*)
	FROM dbo.Member
	WHERE MemberName like '%' + @MemberName + '%'

RETURN