USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_UpdatePetBreed]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_UpdatePetBreed]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_UpdatePetBreed]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_UpdatePetBreed]
	@ID uniqueidentifier,
	@PetAnimalID uniqueidentifier,
	@Name nvarchar(100),
	@DateCreated datetime,
	@CreatedBy nvarchar(256),
	@LastUpdated datetime,
	@LastUpdatedBy nvarchar(256),
	@Visible bit
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE PetBreed
	SET PetAnimalID = @PetAnimalID, Name = @Name, DateCreated = @DateCreated, CreatedBy = @CreatedBy,
		LastUpdated = @LastUpdated, LastUpdatedBy = @LastUpdatedBy, Visible = @Visible
	WHERE ID = @ID

END
GO
