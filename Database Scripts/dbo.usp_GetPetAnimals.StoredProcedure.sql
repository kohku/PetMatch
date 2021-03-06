USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetPetAnimals]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetPetAnimals]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_GetPetAnimals]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetPetAnimals]
	@ID uniqueidentifier = NULL,
	@Name nvarchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID,
		Name,
		DateCreated,
		CreatedBy,
		LastUpdated,
		LastUpdatedBy,
		Visible
	FROM PetAnimal
	WHERE (@ID IS NULL OR ID = @ID)
		AND (@Name IS NULL OR Name LIKE @Name)
	ORDER BY Name

END
GO
