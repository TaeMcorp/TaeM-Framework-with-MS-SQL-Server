CREATE PROCEDURE [dbo].[sp_Memberships_Select_MemberHistory_By_FromToDate]
	@FromDate datetime, 
	@ToDate datetime
AS
	SET NOCOUNT ON;
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;

	SELECT Sequence, MemberID, MemberName, Successful, Message, InsertedDate
	FROM dbo.MemberHistory
	WHERE InsertedDate >= @FromDate AND InsertedDate <= @ToDate
	ORDER BY InsertedDate DESC

RETURN