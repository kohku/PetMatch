USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetPetBreeds]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPetBreeds]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_GetPetBreeds]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetPetBreeds]
	@ID uniqueidentifier = NULL,
	@PetAnimalID uniqueidentifier = NULL,
	@Name nvarchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID,
		PetAnimalID,
		Name,
		DateCreated,
		CreatedBy,
		LastUpdated,
		LastUpdatedBy,
		Visible
	FROM PetBreed
	WHERE (@ID IS NULL OR ID = @ID)
		AND (@PetAnimalID IS NULL OR PetAnimalID LIKE @PetAnimalID)
		AND (@Name IS NULL OR Name LIKE @Name)
	ORDER BY Name

END
GO
