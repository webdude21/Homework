USE [Dictionary]
GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[ExplanationsID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NULL,
	[Explanation] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[ExplanationsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hypernyms]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hypernyms](
	[HypernymID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NOT NULL,
	[HyponymID] [int] NOT NULL,
 CONSTRAINT [PK_Hypernyms] PRIMARY KEY CLUSTERED 
(
	[HypernymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hyponyms]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hyponyms](
	[HyponymID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NOT NULL,
	[HypernymID] [int] NOT NULL,
 CONSTRAINT [PK_Hyponyms] PRIMARY KEY CLUSTERED 
(
	[HyponymID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeach]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeach](
	[PartID] [int] NOT NULL,
	[ExplinationID] [int] NOT NULL,
 CONSTRAINT [PK_PartsOfSpeach] PRIMARY KEY CLUSTERED 
(
	[PartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[EntryID] [int] NOT NULL,
	[WordID] [int] NOT NULL,
	[SynonymID] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[TranslationID] [int] IDENTITY(1,1) NOT NULL,
	[WordID] [int] NOT NULL,
	[Translation] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[TranslationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[WordID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageID] [int] NOT NULL,
	[Word] [nvarchar](50) NOT NULL,
	[TranslationID] [int] NOT NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[WordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[WordsInOtherLanguages]    Script Date: 13.7.2014 г. 19:25:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WordsInOtherLanguages](
	[EntryID] [int] NOT NULL,
	[WordID] [int] NOT NULL,
	[OtherWordID] [int] NOT NULL,
 CONSTRAINT [PK_WordsInOtherLanguages] PRIMARY KEY CLUSTERED 
(
	[EntryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Hypernyms]  WITH CHECK ADD  CONSTRAINT [FK_Hypernyms_Hyponyms] FOREIGN KEY([HyponymID])
REFERENCES [dbo].[Hyponyms] ([HyponymID])
GO
ALTER TABLE [dbo].[Hypernyms] CHECK CONSTRAINT [FK_Hypernyms_Hyponyms]
GO
ALTER TABLE [dbo].[Hypernyms]  WITH CHECK ADD  CONSTRAINT [FK_Hypernyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Hypernyms] CHECK CONSTRAINT [FK_Hypernyms_Words]
GO
ALTER TABLE [dbo].[Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Hyponyms_Hypernyms] FOREIGN KEY([HypernymID])
REFERENCES [dbo].[Hypernyms] ([HypernymID])
GO
ALTER TABLE [dbo].[Hyponyms] CHECK CONSTRAINT [FK_Hyponyms_Hypernyms]
GO
ALTER TABLE [dbo].[Hyponyms]  WITH CHECK ADD  CONSTRAINT [FK_Hyponyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Hyponyms] CHECK CONSTRAINT [FK_Hyponyms_Words]
GO
ALTER TABLE [dbo].[PartsOfSpeach]  WITH CHECK ADD  CONSTRAINT [FK_PartsOfSpeach_Explanations] FOREIGN KEY([ExplinationID])
REFERENCES [dbo].[Explanations] ([ExplanationsID])
GO
ALTER TABLE [dbo].[PartsOfSpeach] CHECK CONSTRAINT [FK_PartsOfSpeach_Explanations]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_WordsInOtherLanguages] FOREIGN KEY([EntryID])
REFERENCES [dbo].[WordsInOtherLanguages] ([EntryID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_WordsInOtherLanguages]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([LanguageID])
REFERENCES [dbo].[Languages] ([LanguageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Translations] FOREIGN KEY([TranslationID])
REFERENCES [dbo].[Translations] ([TranslationID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Translations]
GO
ALTER TABLE [dbo].[WordsInOtherLanguages]  WITH CHECK ADD  CONSTRAINT [FK_WordsInOtherLanguages_Words] FOREIGN KEY([WordID])
REFERENCES [dbo].[Words] ([WordID])
GO
ALTER TABLE [dbo].[WordsInOtherLanguages] CHECK CONSTRAINT [FK_WordsInOtherLanguages_Words]
GO
