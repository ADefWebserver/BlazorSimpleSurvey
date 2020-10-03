SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Logs](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogDate] [datetime] NOT NULL,
	[LogType] [nvarchar](50) NOT NULL,
	[LogDetail] [nvarchar](4000) NOT NULL,
	[LogUserId] [int] NULL,
	[LogIPAddress] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Survey]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Survey](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyName] [nvarchar](500) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateUpdated] [datetime] NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Survey] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyAnswer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyItemId] [int] NOT NULL,
	[AnswerValue] [nvarchar](500) NOT NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_SurveyAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Survey] [int] NOT NULL,
	[ItemLabel] [nvarchar](50) NOT NULL,
	[ItemType] [nvarchar](50) NOT NULL,
	[ItemValue] [nvarchar](50) NULL,
	[Position] [int] NULL,
	[Required] [int] NOT NULL,
	[SurveyChoiceId] [int] NULL,
 CONSTRAINT [PK_SurveyItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SurveyItemOption]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SurveyItemOption](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SurveyItem] [int] NOT NULL,
	[OptionLabel] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_SurveyItemOption] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DisplayName] [nvarchar](1000) NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[Email] [nvarchar](1000) NULL,
	[IdentityProvider] [nvarchar](500) NOT NULL,
	[AuthenticationType] [nvarchar](50) NOT NULL,
	[Objectidentifier] [nvarchar](500) NOT NULL,
	[SigninMethod] [nvarchar](500) NULL,
	[LastIPAddress] [nvarchar](50) NOT NULL,
	[LastAuth_time] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NULL,
	[Lastidp_access_token] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Logs]') AND name = N'IX_Logs')
CREATE NONCLUSTERED INDEX [IX_Logs] ON [dbo].[Logs]
(
	[LogType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Logs_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Logs]'))
ALTER TABLE [dbo].[Logs]  WITH CHECK ADD  CONSTRAINT [FK_Logs_Users] FOREIGN KEY([LogUserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Logs_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Logs]'))
ALTER TABLE [dbo].[Logs] CHECK CONSTRAINT [FK_Logs_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Survey_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Survey]'))
ALTER TABLE [dbo].[Survey]  WITH CHECK ADD  CONSTRAINT [FK_Survey_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Survey_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[Survey]'))
ALTER TABLE [dbo].[Survey] CHECK CONSTRAINT [FK_Survey_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyAnswer_SurveyItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyAnswer]'))
ALTER TABLE [dbo].[SurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SurveyAnswer_SurveyItem] FOREIGN KEY([SurveyItemId])
REFERENCES [dbo].[SurveyItem] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyAnswer_SurveyItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyAnswer]'))
ALTER TABLE [dbo].[SurveyAnswer] CHECK CONSTRAINT [FK_SurveyAnswer_SurveyItem]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyAnswer_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyAnswer]'))
ALTER TABLE [dbo].[SurveyAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SurveyAnswer_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyAnswer_Users]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyAnswer]'))
ALTER TABLE [dbo].[SurveyAnswer] CHECK CONSTRAINT [FK_SurveyAnswer_Users]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyItem_Survey]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyItem]'))
ALTER TABLE [dbo].[SurveyItem]  WITH CHECK ADD  CONSTRAINT [FK_SurveyItem_Survey] FOREIGN KEY([Survey])
REFERENCES [dbo].[Survey] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyItem_Survey]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyItem]'))
ALTER TABLE [dbo].[SurveyItem] CHECK CONSTRAINT [FK_SurveyItem_Survey]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyItemOption_SurveyItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyItemOption]'))
ALTER TABLE [dbo].[SurveyItemOption]  WITH CHECK ADD  CONSTRAINT [FK_SurveyItemOption_SurveyItem] FOREIGN KEY([SurveyItem])
REFERENCES [dbo].[SurveyItem] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_SurveyItemOption_SurveyItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[SurveyItemOption]'))
ALTER TABLE [dbo].[SurveyItemOption] CHECK CONSTRAINT [FK_SurveyItemOption_SurveyItem]
GO
