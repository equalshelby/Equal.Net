USE [Equal_Net]
GO

/****** Object:  Table [dbo].[EM_LoginUser]    Script Date: 2018.1.18 8:55:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EM_LoginUser](
	[Lu_Id] [BIGINT] NOT NULL,
	[Lu_LoginName] [NVARCHAR](50) NULL,
	[Lu_LoginPassWord] [NVARCHAR](50) NULL,
	[Lu_LoginType] [NVARCHAR](50) NULL,
	[Lu_RecordTime] [DATETIME] NOT NULL,
	[Lu_UpdateTime] [DATETIME] NULL,
 CONSTRAINT [PK_EM_LoginUser] PRIMARY KEY CLUSTERED 
(
	[Lu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


