USE [Equal_Net]
GO

/****** Object:  Table [dbo].[EM_LoginToken]    Script Date: 2018.1.18 8:55:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EM_LoginToken](
	[Lt_Id] [BIGINT] NOT NULL,
	[Lt_LoginType] [NVARCHAR](50) NULL,
	[Lt_LoginId] [NVARCHAR](50) NULL,
	[Lt_CreateTime] [DATETIME] NOT NULL,
	[Lt_ExpireTime] [DATETIME] NULL,
	[Lt_Invalid] [BIT] NOT NULL,
	[Lt_RecordTime] [DATETIME] NOT NULL,
	[Lt_UpdateTime] [DATETIME] NULL,
 CONSTRAINT [PK__EM_Login__CBF19547F8ED57E5] PRIMARY KEY CLUSTERED 
(
	[Lt_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


