USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_InsertProvince]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_InsertProvince]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_InsertProvince]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_InsertProvince]
	@ID uniqueidentifier,
	@StateID uniqueidentifier,
	@Name nvarchar(100),
	@DateCreated datetime,
	@CreatedBy nvarchar(256),
	@LastUpdated datetime = NULL,
	@LastUpdatedBy nvarchar(256) = NULL,
	@Visible bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Province
	(ID, StateID, Name, DateCreated, CreatedBy, LastUpdated, LastUpdatedBy, Visible)
	VALUES (@ID, @StateID, @Name, @DateCreated, @CreatedBy, @LastUpdated, @LastUpdatedBy, @Visible)

END
GO
