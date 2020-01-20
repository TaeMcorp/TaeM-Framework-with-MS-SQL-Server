use Product;

-- Member Table Creation Query
CREATE TABLE [dbo].[Member]
(
	[MemberID] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[MemberName] NVARCHAR(100) NULL,
	[IsAvailable] BIT NULL,
	[Email] NVARCHAR(100) NULL,
	[PhoneNumber] NVARCHAR(100) NULL,
	[Address] NVARCHAR(1024) NULL,
	[InsertedDate] DATETIME NULL,
	[UpdatedDate] DATETIME NULL
);

-- Drop table
-- drop table dbo.Member;

-- MemberHistory Table Creation Query
CREATE TABLE [dbo].[MemberHistory]
(
	[Sequence] INT IDENTITY (1, 1) NOT NULL PRIMARY KEY,
	[MemberID] INT NOT NULL,
	[MemberName] NVARCHAR(100) NULL,
	[Successful] BIT NULL DEFAULT 0, 
	[Message] NVARCHAR(1024) NULL,
	[InsertedDate] DATETIME NULL
);

-- Drop table
-- drop table.dbo.MemberHistory;
