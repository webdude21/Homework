USE [master]
GO

IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'EducationalSystem')
BEGIN
DROP DATABASE [EducationalSystem]
END
GO

/****** Object:  Database [EducationalSystem]    Script Date: 22.8.2014 г. 15:39:14 ******/
CREATE DATABASE [EducationalSystem]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EducationalSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EducationalSystem.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'EducationalSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\EducationalSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [EducationalSystem] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EducationalSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [EducationalSystem] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [EducationalSystem] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [EducationalSystem] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [EducationalSystem] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [EducationalSystem] SET ARITHABORT OFF 
GO

ALTER DATABASE [EducationalSystem] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [EducationalSystem] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [EducationalSystem] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [EducationalSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [EducationalSystem] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [EducationalSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [EducationalSystem] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [EducationalSystem] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [EducationalSystem] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [EducationalSystem] SET  DISABLE_BROKER 
GO

ALTER DATABASE [EducationalSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [EducationalSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [EducationalSystem] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [EducationalSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [EducationalSystem] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [EducationalSystem] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [EducationalSystem] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [EducationalSystem] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [EducationalSystem] SET  MULTI_USER 
GO

ALTER DATABASE [EducationalSystem] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [EducationalSystem] SET DB_CHAINING OFF 
GO

ALTER DATABASE [EducationalSystem] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [EducationalSystem] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [EducationalSystem] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [EducationalSystem] SET  READ_WRITE 
GO

USE [EducationalSystem]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[course_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[department_id] [int] NOT NULL,
 CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED 
(
	[course_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[department_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[faculty] [int] NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[department_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Faculties]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Faculties](
	[faculty_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[university_id] [int] NOT NULL,
 CONSTRAINT [PK_Faculties] PRIMARY KEY CLUSTERED 
(
	[faculty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[person_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NOT NULL,
	[age] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Professors]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Professors](
	[person_id] [int] NOT NULL,
	[title_id] [int] NULL,
	[years_of_expirience] [int] NULL,
	[department_id] [int] NULL,
 CONSTRAINT [PK_Professors_1] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Students]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[person_id] [int] NOT NULL,
	[faculty_id] [int] NOT NULL,
	[course_id] [int] NULL,
 CONSTRAINT [PK_Students_1] PRIMARY KEY CLUSTERED 
(
	[person_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Titles]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Titles](
	[title_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Titles] PRIMARY KEY CLUSTERED 
(
	[title_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Universities]    Script Date: 22.8.2014 г. 15:37:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Universities](
	[universitiy_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Universities] PRIMARY KEY CLUSTERED 
(
	[universitiy_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Courses] ON 

INSERT [dbo].[Courses] ([course_id], [name], [department_id]) VALUES (1, N'Структури от данни и програмиране', 1)
INSERT [dbo].[Courses] ([course_id], [name], [department_id]) VALUES (2, N'Основи на компютърната графика', 1)
INSERT [dbo].[Courses] ([course_id], [name], [department_id]) VALUES (3, N'Функционално програмиране', 1)
INSERT [dbo].[Courses] ([course_id], [name], [department_id]) VALUES (4, N'Дизайн и анализ на алгоритми', 1)
SET IDENTITY_INSERT [dbo].[Courses] OFF
SET IDENTITY_INSERT [dbo].[Departments] ON 

INSERT [dbo].[Departments] ([department_id], [name], [faculty]) VALUES (1, N'Информационни Технологии', 1)
INSERT [dbo].[Departments] ([department_id], [name], [faculty]) VALUES (2, N'Математика', 1)
SET IDENTITY_INSERT [dbo].[Departments] OFF
SET IDENTITY_INSERT [dbo].[Faculties] ON 

INSERT [dbo].[Faculties] ([faculty_id], [name], [university_id]) VALUES (1, N'ФАКУЛТЕТ ПО МАТЕМАТИКА И ИНФОРМАТИКА', 1)
INSERT [dbo].[Faculties] ([faculty_id], [name], [university_id]) VALUES (2, N'БОГОСЛОВСКИ ФАКУЛТЕТ', 1)
INSERT [dbo].[Faculties] ([faculty_id], [name], [university_id]) VALUES (3, N'СТОПАНСКИ ФАКУЛТЕТ', 1)
INSERT [dbo].[Faculties] ([faculty_id], [name], [university_id]) VALUES (4, N'ГЕОЛОГО-ГЕОГРАФСКИ ФАКУЛТЕТ', 1)
SET IDENTITY_INSERT [dbo].[Faculties] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (8, N'Иван', N'Иванов', 72)
INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (9, N'Георги', N'Ганков', 22)
INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (10, N'Димо', N'Петров', 28)
INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (11, N'Петър', N'Петров', 62)
INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (12, N'Димитър', N'Терзиев', 21)
INSERT [dbo].[Persons] ([person_id], [first_name], [last_name], [age]) VALUES (13, N'Калина', N'Томова', 20)
SET IDENTITY_INSERT [dbo].[Persons] OFF
INSERT [dbo].[Professors] ([person_id], [title_id], [years_of_expirience], [department_id]) VALUES (8, 1, 35, 1)
INSERT [dbo].[Professors] ([person_id], [title_id], [years_of_expirience], [department_id]) VALUES (11, 2, 24, 1)
INSERT [dbo].[Students] ([person_id], [faculty_id], [course_id]) VALUES (9, 1, NULL)
INSERT [dbo].[Students] ([person_id], [faculty_id], [course_id]) VALUES (10, 1, NULL)
INSERT [dbo].[Students] ([person_id], [faculty_id], [course_id]) VALUES (12, 3, NULL)
INSERT [dbo].[Students] ([person_id], [faculty_id], [course_id]) VALUES (13, 2, NULL)
SET IDENTITY_INSERT [dbo].[Titles] ON 

INSERT [dbo].[Titles] ([title_id], [name]) VALUES (1, N'Професор')
INSERT [dbo].[Titles] ([title_id], [name]) VALUES (2, N'Доцент')
INSERT [dbo].[Titles] ([title_id], [name]) VALUES (3, N'Гл. Асистент')
SET IDENTITY_INSERT [dbo].[Titles] OFF
SET IDENTITY_INSERT [dbo].[Universities] ON 

INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (1, N'Софийски Университет „Св. Климент Охридски“')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (2, N'Минно-геоложкият университет "Св. Иван Рилски"')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (3, N'Технически университет')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (4, N'Университет за национално и световно стопанство')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (5, N'Великотърновски университет')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (6, N'Тракийски университет')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (7, N'Химикотехнологичен и металургичен университет')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (8, N'Университет по архитектура, строителство и геодезия')
INSERT [dbo].[Universities] ([universitiy_id], [name]) VALUES (9, N'Лесотехнически университет')
SET IDENTITY_INSERT [dbo].[Universities] OFF
ALTER TABLE [dbo].[Courses]  WITH CHECK ADD  CONSTRAINT [FK_Courses_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([department_id])
GO
ALTER TABLE [dbo].[Courses] CHECK CONSTRAINT [FK_Courses_Departments]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [FK_Departments_Faculties] FOREIGN KEY([faculty])
REFERENCES [dbo].[Faculties] ([faculty_id])
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [FK_Departments_Faculties]
GO
ALTER TABLE [dbo].[Faculties]  WITH CHECK ADD  CONSTRAINT [FK_Faculties_Universities] FOREIGN KEY([university_id])
REFERENCES [dbo].[Universities] ([universitiy_id])
GO
ALTER TABLE [dbo].[Faculties] CHECK CONSTRAINT [FK_Faculties_Universities]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Departments] FOREIGN KEY([department_id])
REFERENCES [dbo].[Departments] ([department_id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Departments]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Persons1] FOREIGN KEY([person_id])
REFERENCES [dbo].[Persons] ([person_id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Persons1]
GO
ALTER TABLE [dbo].[Professors]  WITH CHECK ADD  CONSTRAINT [FK_Professors_Titles] FOREIGN KEY([title_id])
REFERENCES [dbo].[Titles] ([title_id])
GO
ALTER TABLE [dbo].[Professors] CHECK CONSTRAINT [FK_Professors_Titles]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Courses] FOREIGN KEY([course_id])
REFERENCES [dbo].[Courses] ([course_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Courses]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Faculties] FOREIGN KEY([faculty_id])
REFERENCES [dbo].[Faculties] ([faculty_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Faculties]
GO
ALTER TABLE [dbo].[Students]  WITH CHECK ADD  CONSTRAINT [FK_Students_Persons] FOREIGN KEY([person_id])
REFERENCES [dbo].[Persons] ([person_id])
GO
ALTER TABLE [dbo].[Students] CHECK CONSTRAINT [FK_Students_Persons]
GO