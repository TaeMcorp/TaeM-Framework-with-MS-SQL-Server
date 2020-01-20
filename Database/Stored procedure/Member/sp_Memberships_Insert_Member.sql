CREATE PROCEDURE [dbo].[sp_Memberships_Insert_Member]
	@MemberName nvarchar(100),
	@IsAvailable bit,
	@Email nvarchar(100), 
	@PhoneNumber nvarchar(100),
	@Address nvarchar(1024)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	BEGIN TRANSACTION

		INSERT INTO dbo.Member
		( MemberName, IsAvailable, Email, PhoneNumber, Address, InsertedDate, UpdatedDate )
		VALUES 
		( @MemberName, @IsAvailable, @Email, @PhoneNumber, @Address, GETDATE(), NULL )

		SELECT MemberID, MemberName, IsAvailable, Email, PhoneNumber, Address, InsertedDate, UpdatedDate
		FROM dbo.Member
		WHERE MemberName = @MemberName AND IsAvailable = @IsAvailable AND Email = @Email 
			AND PhoneNumber = @PhoneNumber AND Address = @Address
		ORDER BY InsertedDate DESC

	COMMIT

RETURN