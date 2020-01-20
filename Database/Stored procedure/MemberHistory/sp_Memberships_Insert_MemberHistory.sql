CREATE PROCEDURE [dbo].[sp_Memberships_Insert_MemberHistory]
	@MemberID int,
	@MemberName nvarchar(100),
	@Successful bit,
	@Message nvarchar(1024)
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	BEGIN TRANSACTION

		INSERT INTO dbo.MemberHistory
		( MemberID, MemberName, Successful, Message, InsertedDate )
		VALUES 
		( @MemberID, @MemberName, @Successful, @Message, GETDATE() )

		SELECT Sequence, MemberID, MemberName, Successful, Message, InsertedDate
		FROM dbo.MemberHistory
		WHERE MemberID = @MemberID AND MemberName = @MemberName 
			AND Successful = @Successful AND Message = @Message
		ORDER BY InsertedDate DESC

	COMMIT

RETURN