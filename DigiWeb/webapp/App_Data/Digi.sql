USE [DigiWeb]
GO
/****** Object:  Table [dbo].[BM_KeyValue]    Script Date: 2018.4.15 17:37:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BM_KeyValue](
	[Kv_Id] [bigint] NOT NULL,
	[Kv_Key] [nvarchar](200) NULL,
	[Kv_Value] [nvarchar](max) NULL,
	[Kv_AdditionalData] [nvarchar](max) NULL,
	[Kv_RecordTime] [datetime] NOT NULL CONSTRAINT [DF_BM_KeyValue_Kv_RecordTime]  DEFAULT (getdate()),
	[Kv_UpdateTime] [datetime] NULL,
 CONSTRAINT [PK_BM_KeyValue] PRIMARY KEY CLUSTERED 
(
	[Kv_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[BM_KeyValue] ([Kv_Id], [Kv_Key], [Kv_Value], [Kv_AdditionalData], [Kv_RecordTime], [Kv_UpdateTime]) VALUES (170183582927552512, N'Nav', N'测试导航1', N'../pages/index.aspx', CAST(N'2018-04-15 14:48:48.033' AS DateTime), NULL)
INSERT [dbo].[BM_KeyValue] ([Kv_Id], [Kv_Key], [Kv_Value], [Kv_AdditionalData], [Kv_RecordTime], [Kv_UpdateTime]) VALUES (170183605371273216, N'Nav', N'测试导航2', N'../pages/about.aspx', CAST(N'2018-04-15 14:48:53.377' AS DateTime), NULL)
INSERT [dbo].[BM_KeyValue] ([Kv_Id], [Kv_Key], [Kv_Value], [Kv_AdditionalData], [Kv_RecordTime], [Kv_UpdateTime]) VALUES (170188998046646272, N'Nav', N'测试导航4', N'../pages/advertise.aspx', CAST(N'2018-04-15 15:10:19.097' AS DateTime), NULL)
INSERT [dbo].[BM_KeyValue] ([Kv_Id], [Kv_Key], [Kv_Value], [Kv_AdditionalData], [Kv_RecordTime], [Kv_UpdateTime]) VALUES (170189022562353156, N'Nav', N'测试导航5', N'../pages/apple.aspx', CAST(N'2018-04-15 15:10:24.937' AS DateTime), NULL)
INSERT [dbo].[BM_KeyValue] ([Kv_Id], [Kv_Key], [Kv_Value], [Kv_AdditionalData], [Kv_RecordTime], [Kv_UpdateTime]) VALUES (170189046805430277, N'Nav', N'测试导航6', N'../pages/QA.aspx', CAST(N'2018-04-15 15:10:30.717' AS DateTime), NULL)
