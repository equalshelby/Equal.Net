﻿SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EM_CommonUser](
	[Cu_Id] [BIGINT] NOT NULL,
	[Cu_RelatedDomain] [NVARCHAR](50) NULL,
	[Cu_RelatedDomainId] [NVARCHAR](50) NULL,
	[Cu_ChineseName] [NVARCHAR](50) NULL,
	[Cu_Sex] [INT] NOT NULL,
	[Cu_Department] [NVARCHAR](50) NULL,
	[Cu_JobTitle] [INT] NOT NULL,
	[Cu_Mobile] [NVARCHAR](50) NULL,
	[Cu_Email] [NVARCHAR](50) NULL,
	[Cu_Note] [NVARCHAR](50) NULL,
	[Cu_Number] [NVARCHAR](50) NULL,
	[Cu_WorkingState] [INT] NOT NULL,
	[Cu_RecordTime] [DATETIME] NOT NULL,
	[Cu_UpdateTime] [DATETIME] NULL,
PRIMARY KEY CLUSTERED 
(
	[Cu_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO