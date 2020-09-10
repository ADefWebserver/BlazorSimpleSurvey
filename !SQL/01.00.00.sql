/****** Object:  Table [dbo].[Users]    Script Date: 9/9/2020 5:28:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](1000) NOT NULL,
	[DisplayName] [nvarchar](1000) NULL,
	[FirstName] [nvarchar](500) NULL,
	[LastName] [nvarchar](500) NULL,
	[Email] [nvarchar](1000) NULL,
	[IdentityProvider] [nvarchar](500) NOT NULL,
	[AuthenticationType] [nvarchar](50) NOT NULL,
	[Objectidentifier] [nvarchar](500) NOT NULL,
	[SignupMethod] [nvarchar](500) NULL,
	[LastIPAddress] [nvarchar](50) NOT NULL,
	[LastAuth_time] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[Lastidp_access_token] [nvarchar](4000) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

