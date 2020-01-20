CREATE PROCEDURE [dbo].[sp_Memberships_Update_Member]
	@MemberID int,
	@MemberName nvarchar(100),
	@IsAvailable bit,
	@Email nvarchar(100), 
	@PhoneNumber nvarchar(100),
	@Address nvarchar(1024)
AS
	SET NOCOUNT OFF;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	UPDATE dbo.Member
	SET MemberName = @MemberName, IsAvailable = @IsAvailable, Email = @Email, 
		PhoneNumber = @PhoneNumber, Address = @Address, UpdatedDate = GETDATE()
	WHERE MemberID = @MemberID
	
RETURN