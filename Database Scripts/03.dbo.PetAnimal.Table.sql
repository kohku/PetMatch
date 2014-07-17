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


