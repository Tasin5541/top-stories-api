USE [NYTStories]
GO
/****** Object:  Table [dbo].[MultiMedia]    Script Date: 8/21/2022 12:14:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MultiMedia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[StoryId] [int] NOT NULL,
	[Url] [nvarchar](250) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LastModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_MultiMedia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TopStory]    Script Date: 8/21/2022 12:14:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TopStory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Section] [nvarchar](50) NOT NULL,
	[SubSection] [nvarchar](50) NULL,
	[Title] [nvarchar](250) NOT NULL,
	[Abstract] [nvarchar](max) NOT NULL,
	[Url] [nvarchar](250) NOT NULL,
	[Byline] [nvarchar](250) NOT NULL,
	[Type] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[LastModifiedTime] [datetime] NOT NULL,
 CONSTRAINT [PK_TopStory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[MultiMedia] ADD  CONSTRAINT [DF_MultiMedia_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[MultiMedia] ADD  CONSTRAINT [DF_MultiMedia_LastModifiedTime]  DEFAULT (getdate()) FOR [LastModifiedTime]
GO
ALTER TABLE [dbo].[TopStory] ADD  CONSTRAINT [DF_TopStory_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO
ALTER TABLE [dbo].[TopStory] ADD  CONSTRAINT [DF_TopStory_LastModifiedTime]  DEFAULT (getdate()) FOR [LastModifiedTime]
GO
ALTER TABLE [dbo].[MultiMedia]  WITH CHECK ADD  CONSTRAINT [FK_MultiMedia_MultiMedia] FOREIGN KEY([StoryId])
REFERENCES [dbo].[TopStory] ([Id])
GO
ALTER TABLE [dbo].[MultiMedia] CHECK CONSTRAINT [FK_MultiMedia_MultiMedia]
GO
