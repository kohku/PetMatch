USE [PetMatchStorage]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PetAnimal_ID]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PetAnimal] DROP CONSTRAINT [DF_PetAnimal_ID]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PetAnimal_DateCreated]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PetAnimal] DROP CONSTRAINT [DF_PetAnimal_DateCreated]
END

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_PetAnimal_Visible]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[PetAnimal] DROP CONSTRAINT [DF_PetAnimal_Visible]
END

GO

USE [PetMatchStorage]
GO

/****** Object:  Table [dbo].[PetAnimal]    Script Date: 06/25/2014 22:29:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PetAnimal]') AND type in (N'U'))
DROP TABLE [dbo].[PetAnimal]
GO

USE [PetMatchStorage]
GO

/****** Object:  Table [dbo].[PetAnimal]    Script Date: 06/25/2014 22:29:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PetAnimal](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[LastUpdated] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](256) NULL,
	[Visible] [bit] NOT NULL,
 CONSTRAINT [PK_PetAnimal] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PetAnimal] ADD  CONSTRAINT [DF_PetAnimal_ID]  DEFAULT (newid()) FOR [ID]
GO

ALTER TABLE [dbo].[PetAnimal] ADD  CONSTRAINT [DF_PetAnimal_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [dbo].[PetAnimal] ADD  CONSTRAINT [DF_PetAnimal_Visible]  DEFAULT ((0)) FOR [Visible]
GO

INSERT [dbo].[PetAnimal] ([ID], [Name], [DateCreated], [CreatedBy], [LastUpdated], [LastUpdatedBy], [Visible]) VALUES (N'e6f03c12-f545-4072-88de-01cf7c93b3b2', N'Perro', CAST(0x0000A356004D9EAA AS DateTime), N'dcruz', NULL, NULL, 1)
INSERT [dbo].[PetAnimal] ([ID], [Name], [DateCreated], [CreatedBy], [LastUpdated], [LastUpdatedBy], [Visible]) VALUES (N'be3d8e61-ca09-4a11-8e61-2f094d47c131', N'Gato', CAST(0x0000A356004DA6A2 AS DateTime), N'dcruz', NULL, NULL, 1)
INSERT [dbo].[PetAnimal] ([ID], [Name], [DateCreated], [CreatedBy], [LastUpdated], [LastUpdatedBy], [Visible]) VALUES (N'a93ea087-14fb-49f3-a927-e80c1dccceb0', N'Ave', CAST(0x0000A35600514321 AS DateTime), N'dcruz', NULL, NULL, 1)
INSERT [dbo].[PetAnimal] ([ID], [Name], [DateCreated], [CreatedBy], [LastUpdated], [LastUpdatedBy], [Visible]) VALUES (N'44e0c64d-de53-4ed5-b06c-ee53af31c546', N'Reptil', CAST(0x0000A3560050E15B AS DateTime), N'dcruz', NULL, NULL, 1)

