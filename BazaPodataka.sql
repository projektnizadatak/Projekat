USE [master]
GO
/****** Object:  Database [ProjektniZadatak]    Script Date: 4/5/2017 12:43:55 ******/
CREATE DATABASE [ProjektniZadatak]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjektniZadatak', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjektniZadatak.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ProjektniZadatak_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\ProjektniZadatak_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ProjektniZadatak] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjektniZadatak].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjektniZadatak] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjektniZadatak] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjektniZadatak] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjektniZadatak] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjektniZadatak] SET  MULTI_USER 
GO
ALTER DATABASE [ProjektniZadatak] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjektniZadatak] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjektniZadatak] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjektniZadatak] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ProjektniZadatak] SET DELAYED_DURABILITY = DISABLED 
GO
USE [ProjektniZadatak]
GO
/****** Object:  Table [dbo].[adresa]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[adresa](
	[sifraAdrese] [int] IDENTITY(1,1) NOT NULL,
	[adresa] [varchar](50) NOT NULL,
	[broj] [varchar](10) NOT NULL,
	[sifraTipaAdrese] [int] NOT NULL,
	[sifraKorisnika] [int] NOT NULL,
	[sifraGrada] [int] NOT NULL,
	[sifraOpstine] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraAdrese] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[emailAdresa]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[emailAdresa](
	[sifraEmail] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[sifraTipaEmail] [int] NOT NULL,
	[sifraKorisnika] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[fiksniTelefon]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fiksniTelefon](
	[sifraTelefona] [int] NOT NULL,
	[sifraLokala] [int] NOT NULL,
	[sifraTipaFiksnog] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[grad]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[grad](
	[sifraGrada] [int] IDENTITY(1,1) NOT NULL,
	[nazivGrada] [varchar](30) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraGrada] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[kontaktTelefon]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[kontaktTelefon](
	[sifraTelefona] [int] IDENTITY(1,1) NOT NULL,
	[brojTelefona] [varchar](20) NOT NULL,
	[sifraKorisnika] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[korisnik]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[korisnik](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[korisnickoIme] [varchar](20) NULL,
	[lozinka] [varchar](20) NULL,
	[sifraPravaPristupa] [int] NULL,
	[ime] [varchar](15) NULL,
	[prezime] [varchar](20) NULL,
	[imeRoditelja] [varchar](15) NULL,
	[jmbg] [varchar](13) NULL,
	[brojLicneKarte] [varchar](9) NULL,
	[datumRodjenja] [date] NULL,
	[sifraMestaRodjenja] [int] NULL,
	[sifraOpstineRodjenja] [int] NULL,
	[sifraPola] [int] NULL,
	[fotografija] [varchar](max) NULL,
	[beleska] [text] NULL,
 CONSTRAINT [PK__korisnik__3213E83F90CF1913] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[lokalFiksni]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lokalFiksni](
	[sifraLokala] [int] IDENTITY(1,1) NOT NULL,
	[lokal] [varchar](5) NOT NULL,
 CONSTRAINT [PK__lokalFik__0AE53188F64A1DB5] PRIMARY KEY CLUSTERED 
(
	[sifraLokala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[lokalMobilni]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[lokalMobilni](
	[sifraLokala] [int] IDENTITY(1,1) NOT NULL,
	[lokal] [varchar](3) NOT NULL,
 CONSTRAINT [PK__lokalMob__0AE531883FAD346B] PRIMARY KEY CLUSTERED 
(
	[sifraLokala] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[mobilniTelefon]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mobilniTelefon](
	[sifraTelefona] [int] NOT NULL,
	[sifraLokala] [int] NOT NULL,
	[sifraTipaMobilnog] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTelefona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[opstina]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[opstina](
	[sifraGrada] [int] NOT NULL,
	[sifraOpstine] [int] IDENTITY(1,1) NOT NULL,
	[nazivOpstine] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraGrada] ASC,
	[sifraOpstine] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pol]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pol](
	[sifraPola] [int] IDENTITY(1,1) NOT NULL,
	[nazivPola] [varchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraPola] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[pravoPristupa]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pravoPristupa](
	[sifraPristupa] [int] IDENTITY(1,1) NOT NULL,
	[nazivPristupa] [varchar](25) NOT NULL,
 CONSTRAINT [PK__pravoPri__566947F03CBF0907] PRIMARY KEY CLUSTERED 
(
	[sifraPristupa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipAdrese]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipAdrese](
	[sifraTipa] [int] IDENTITY(1,1) NOT NULL,
	[nazivTipa] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTipa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipMailAdrese]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipMailAdrese](
	[sifraTipa] [int] IDENTITY(1,1) NOT NULL,
	[nazivTipa] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTipa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tipTelefona]    Script Date: 4/5/2017 12:43:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tipTelefona](
	[sifraTipa] [int] IDENTITY(1,1) NOT NULL,
	[nazivTipa] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[sifraTipa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[adresa] ON 

INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (28, N'pera', N'1', 1, 35, 1, 1)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (29, N'pera', N'2', 2, 35, 1, 1)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (30, N'pera', N'3', 3, 35, 1, 1)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (37, N'Neka adresa', N'10a', 1, 25, 2, 18)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (39, N'Neka adresa', N'100', 1, 26, 1, 8)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (46, N'Moja Kucna Adresa', N'1', 1, 40, 1, 1)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (47, N'Moja Poslovna Adresa', N'2', 2, 40, 2, 18)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (48, N'Moja Adresa Licne Karte', N'3', 3, 40, 3, 22)
INSERT [dbo].[adresa] ([sifraAdrese], [adresa], [broj], [sifraTipaAdrese], [sifraKorisnika], [sifraGrada], [sifraOpstine]) VALUES (55, N'Druga adresa', N'10', 2, 25, 1, 6)
SET IDENTITY_INSERT [dbo].[adresa] OFF
SET IDENTITY_INSERT [dbo].[emailAdresa] ON 

INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (17, N'pera@gmail.com', 1, 35)
INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (18, N'peraposao@gmail.com', 2, 35)
INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (24, N'tamara@gmail.com', 1, 26)
INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (25, N'tamaraposao@gmail.com', 2, 26)
INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (28, N'prva@mail.com', 1, 40)
INSERT [dbo].[emailAdresa] ([sifraEmail], [email], [sifraTipaEmail], [sifraKorisnika]) VALUES (29, N'druga@mail.com', 2, 40)
SET IDENTITY_INSERT [dbo].[emailAdresa] OFF
INSERT [dbo].[fiksniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaFiksnog]) VALUES (33, 1, 3)
INSERT [dbo].[fiksniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaFiksnog]) VALUES (34, 2, 6)
INSERT [dbo].[fiksniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaFiksnog]) VALUES (44, 1, 3)
INSERT [dbo].[fiksniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaFiksnog]) VALUES (54, 1, 3)
INSERT [dbo].[fiksniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaFiksnog]) VALUES (55, 2, 6)
SET IDENTITY_INSERT [dbo].[grad] ON 

INSERT [dbo].[grad] ([sifraGrada], [nazivGrada]) VALUES (1, N'Beograd')
INSERT [dbo].[grad] ([sifraGrada], [nazivGrada]) VALUES (2, N'Novi Sad')
INSERT [dbo].[grad] ([sifraGrada], [nazivGrada]) VALUES (3, N'Nis')
INSERT [dbo].[grad] ([sifraGrada], [nazivGrada]) VALUES (4, N'Kragujevac')
SET IDENTITY_INSERT [dbo].[grad] OFF
SET IDENTITY_INSERT [dbo].[kontaktTelefon] ON 

INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (31, N'123', 35)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (32, N'123', 35)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (33, N'123', 35)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (34, N'123', 35)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (43, N'123456', 25)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (44, N'233321', 25)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (46, N'232134', 26)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (52, N'1234567', 40)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (53, N'123456', 40)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (54, N'1234567', 40)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (55, N'123456', 40)
INSERT [dbo].[kontaktTelefon] ([sifraTelefona], [brojTelefona], [sifraKorisnika]) VALUES (60, N'555333', 25)
SET IDENTITY_INSERT [dbo].[kontaktTelefon] OFF
SET IDENTITY_INSERT [dbo].[korisnik] ON 

INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (25, N'aleksandar', N'123123123a', 1, N'Aleksandar', N'Zivkovic', N'', N'1111111111111', N'043356477', CAST(N'2000-01-01' AS Date), 0, 0, 2, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\578b034f-98d4-45cf-9506-c13ef2c421de.jpg', N'Nova beleska')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (26, N'tamara', N'123123123a', 1, N'Tamara', N'Mijailovic', N'', N'1111111111111', N'055665378', CAST(N'2000-01-01' AS Date), 0, 0, 1, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\430edabb-f55f-4dd6-b1ed-cc62ad68d5db.jpg', N'                                    ')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (27, N'vladimir', N'123123123a', 1, N'Vladimir', N'Janjic', N'Dragan', N'1111111111111', N'043362688', CAST(N'2000-01-01' AS Date), 0, 0, 2, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\12b38853-92dc-4bc4-b673-8dd458200912.jpg', N'')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (28, N'urosuros', N'123123123a', 1, N'Uros', N'Boric', N'', N'1111111111111', N'248849000', CAST(N'2000-01-01' AS Date), 0, 0, 2, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\9f46bfa1-90c9-450b-8b78-37add436b596.jpg', N'')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (29, N'milosmilos', N'123123123a', 2, N'Milos', N'Nedeljkovic', N'', N'1111111111111', N'023398748', CAST(N'2000-01-01' AS Date), 0, 0, 2, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\0b9f447f-f54f-4cf7-9b5f-367a2873fb6e.jpg', N'')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (35, N'perapera', N'123123123a', 1, N'Pera', N'Peric', N'Pera', N'1111111111111', N'111111111', CAST(N'2000-01-01' AS Date), 1, 1, 2, N'C:\Users\Kristina\Desktop\ProjektniZadatakRadnaVerzija3\ProjektniZadatakRadnaVerzija1\image\d7cd0176-f9e6-45ff-b534-370e969565f5.jpg', N'')
INSERT [dbo].[korisnik] ([id], [korisnickoIme], [lozinka], [sifraPravaPristupa], [ime], [prezime], [imeRoditelja], [jmbg], [brojLicneKarte], [datumRodjenja], [sifraMestaRodjenja], [sifraOpstineRodjenja], [sifraPola], [fotografija], [beleska]) VALUES (40, N'kristina', N'123123123a', 3, N'Kristina', N'Staletovic', N'Mitrasin', N'1111111111111', N'111111111', CAST(N'1990-10-10' AS Date), 1, 12, 1, N'C:\Users\janji\Desktop\Totalna Dominacija3.1\ProjektniZadatakRadnaVerzija1\image\fc9ecb4c-a876-47ab-9a53-cc9a8dbff748.jpg', N'AAAAAAAAAAAAAA')
SET IDENTITY_INSERT [dbo].[korisnik] OFF
SET IDENTITY_INSERT [dbo].[lokalFiksni] ON 

INSERT [dbo].[lokalFiksni] ([sifraLokala], [lokal]) VALUES (1, N'011')
INSERT [dbo].[lokalFiksni] ([sifraLokala], [lokal]) VALUES (2, N'021')
INSERT [dbo].[lokalFiksni] ([sifraLokala], [lokal]) VALUES (3, N'018')
INSERT [dbo].[lokalFiksni] ([sifraLokala], [lokal]) VALUES (4, N'034')
SET IDENTITY_INSERT [dbo].[lokalFiksni] OFF
SET IDENTITY_INSERT [dbo].[lokalMobilni] ON 

INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (1, N'060')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (2, N'061')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (3, N'062')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (4, N'063')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (5, N'064')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (6, N'065')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (7, N'066')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (8, N'068')
INSERT [dbo].[lokalMobilni] ([sifraLokala], [lokal]) VALUES (9, N'069')
SET IDENTITY_INSERT [dbo].[lokalMobilni] OFF
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (31, 2, 1)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (32, 3, 2)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (43, 2, 1)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (46, 6, 2)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (52, 1, 1)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (53, 2, 2)
INSERT [dbo].[mobilniTelefon] ([sifraTelefona], [sifraLokala], [sifraTipaMobilnog]) VALUES (60, 8, 2)
SET IDENTITY_INSERT [dbo].[opstina] ON 

INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 1, N'Cukarica')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 2, N'Novi Beograd')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 3, N'Palilula')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 4, N'Rakovica')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 5, N'Savski venac')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 6, N'Stari grad')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 7, N'Vozdovac')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 8, N'Vracar')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 9, N'Zemun')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 10, N'Zvezdara')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 11, N'Barajevo')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 12, N'Grocka')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 13, N'Mladenovac')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 14, N'Obrenovac')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 15, N'Surcin')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 16, N'Lazarevac')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (1, 17, N'Sopot')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (2, 18, N'Novi Sad')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (2, 19, N'Petrovaradin')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (2, 30, N'Novi')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (3, 20, N'Medijana')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (3, 21, N'Palilula')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (3, 22, N'Pantelej')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (3, 23, N'Crveni Krst')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (3, 24, N'Niska banja')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (4, 25, N'Aerodrom')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (4, 26, N'Stari grad')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (4, 27, N'Stanovo')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (4, 28, N'Stragari')
INSERT [dbo].[opstina] ([sifraGrada], [sifraOpstine], [nazivOpstine]) VALUES (4, 29, N'Pivara')
SET IDENTITY_INSERT [dbo].[opstina] OFF
SET IDENTITY_INSERT [dbo].[pol] ON 

INSERT [dbo].[pol] ([sifraPola], [nazivPola]) VALUES (1, N'Zenski')
INSERT [dbo].[pol] ([sifraPola], [nazivPola]) VALUES (2, N'Muski')
SET IDENTITY_INSERT [dbo].[pol] OFF
SET IDENTITY_INSERT [dbo].[pravoPristupa] ON 

INSERT [dbo].[pravoPristupa] ([sifraPristupa], [nazivPristupa]) VALUES (1, N'Pravo administracije')
INSERT [dbo].[pravoPristupa] ([sifraPristupa], [nazivPristupa]) VALUES (2, N'Pravo unosa')
INSERT [dbo].[pravoPristupa] ([sifraPristupa], [nazivPristupa]) VALUES (3, N'Pravo pregleda')
SET IDENTITY_INSERT [dbo].[pravoPristupa] OFF
SET IDENTITY_INSERT [dbo].[tipAdrese] ON 

INSERT [dbo].[tipAdrese] ([sifraTipa], [nazivTipa]) VALUES (1, N'Kuca')
INSERT [dbo].[tipAdrese] ([sifraTipa], [nazivTipa]) VALUES (2, N'Posao')
INSERT [dbo].[tipAdrese] ([sifraTipa], [nazivTipa]) VALUES (3, N'Licna karta')
SET IDENTITY_INSERT [dbo].[tipAdrese] OFF
SET IDENTITY_INSERT [dbo].[tipMailAdrese] ON 

INSERT [dbo].[tipMailAdrese] ([sifraTipa], [nazivTipa]) VALUES (1, N'Privatna')
INSERT [dbo].[tipMailAdrese] ([sifraTipa], [nazivTipa]) VALUES (2, N'Posao')
SET IDENTITY_INSERT [dbo].[tipMailAdrese] OFF
SET IDENTITY_INSERT [dbo].[tipTelefona] ON 

INSERT [dbo].[tipTelefona] ([sifraTipa], [nazivTipa]) VALUES (1, N'Mobilni')
INSERT [dbo].[tipTelefona] ([sifraTipa], [nazivTipa]) VALUES (2, N'Sluzbeni mobilni')
INSERT [dbo].[tipTelefona] ([sifraTipa], [nazivTipa]) VALUES (3, N'Posao')
INSERT [dbo].[tipTelefona] ([sifraTipa], [nazivTipa]) VALUES (6, N'Kuca')
SET IDENTITY_INSERT [dbo].[tipTelefona] OFF
ALTER TABLE [dbo].[adresa]  WITH CHECK ADD  CONSTRAINT [fk_gradOpstinaAdresa] FOREIGN KEY([sifraGrada], [sifraOpstine])
REFERENCES [dbo].[opstina] ([sifraGrada], [sifraOpstine])
GO
ALTER TABLE [dbo].[adresa] CHECK CONSTRAINT [fk_gradOpstinaAdresa]
GO
ALTER TABLE [dbo].[adresa]  WITH CHECK ADD  CONSTRAINT [fk_korisnikAdresa] FOREIGN KEY([sifraKorisnika])
REFERENCES [dbo].[korisnik] ([id])
GO
ALTER TABLE [dbo].[adresa] CHECK CONSTRAINT [fk_korisnikAdresa]
GO
ALTER TABLE [dbo].[adresa]  WITH CHECK ADD  CONSTRAINT [fk_tipAdresa] FOREIGN KEY([sifraTipaAdrese])
REFERENCES [dbo].[tipAdrese] ([sifraTipa])
GO
ALTER TABLE [dbo].[adresa] CHECK CONSTRAINT [fk_tipAdresa]
GO
ALTER TABLE [dbo].[emailAdresa]  WITH CHECK ADD  CONSTRAINT [fk_korisnikEmail] FOREIGN KEY([sifraKorisnika])
REFERENCES [dbo].[korisnik] ([id])
GO
ALTER TABLE [dbo].[emailAdresa] CHECK CONSTRAINT [fk_korisnikEmail]
GO
ALTER TABLE [dbo].[emailAdresa]  WITH CHECK ADD  CONSTRAINT [fk_tipEmail] FOREIGN KEY([sifraTipaEmail])
REFERENCES [dbo].[tipMailAdrese] ([sifraTipa])
GO
ALTER TABLE [dbo].[emailAdresa] CHECK CONSTRAINT [fk_tipEmail]
GO
ALTER TABLE [dbo].[fiksniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_lokalFix] FOREIGN KEY([sifraLokala])
REFERENCES [dbo].[lokalFiksni] ([sifraLokala])
GO
ALTER TABLE [dbo].[fiksniTelefon] CHECK CONSTRAINT [fk_lokalFix]
GO
ALTER TABLE [dbo].[fiksniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_sifraFix] FOREIGN KEY([sifraTelefona])
REFERENCES [dbo].[kontaktTelefon] ([sifraTelefona])
GO
ALTER TABLE [dbo].[fiksniTelefon] CHECK CONSTRAINT [fk_sifraFix]
GO
ALTER TABLE [dbo].[fiksniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_tipFix] FOREIGN KEY([sifraTipaFiksnog])
REFERENCES [dbo].[tipTelefona] ([sifraTipa])
GO
ALTER TABLE [dbo].[fiksniTelefon] CHECK CONSTRAINT [fk_tipFix]
GO
ALTER TABLE [dbo].[kontaktTelefon]  WITH CHECK ADD  CONSTRAINT [fk_korisnikTel] FOREIGN KEY([sifraKorisnika])
REFERENCES [dbo].[korisnik] ([id])
GO
ALTER TABLE [dbo].[kontaktTelefon] CHECK CONSTRAINT [fk_korisnikTel]
GO
ALTER TABLE [dbo].[mobilniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_lokalMob] FOREIGN KEY([sifraLokala])
REFERENCES [dbo].[lokalMobilni] ([sifraLokala])
GO
ALTER TABLE [dbo].[mobilniTelefon] CHECK CONSTRAINT [fk_lokalMob]
GO
ALTER TABLE [dbo].[mobilniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_sifraMob] FOREIGN KEY([sifraTelefona])
REFERENCES [dbo].[kontaktTelefon] ([sifraTelefona])
GO
ALTER TABLE [dbo].[mobilniTelefon] CHECK CONSTRAINT [fk_sifraMob]
GO
ALTER TABLE [dbo].[mobilniTelefon]  WITH CHECK ADD  CONSTRAINT [fk_tipMob] FOREIGN KEY([sifraTipaMobilnog])
REFERENCES [dbo].[tipTelefona] ([sifraTipa])
GO
ALTER TABLE [dbo].[mobilniTelefon] CHECK CONSTRAINT [fk_tipMob]
GO
ALTER TABLE [dbo].[opstina]  WITH CHECK ADD  CONSTRAINT [sGrada] FOREIGN KEY([sifraGrada])
REFERENCES [dbo].[grad] ([sifraGrada])
GO
ALTER TABLE [dbo].[opstina] CHECK CONSTRAINT [sGrada]
GO
USE [master]
GO
ALTER DATABASE [ProjektniZadatak] SET  READ_WRITE 
GO
