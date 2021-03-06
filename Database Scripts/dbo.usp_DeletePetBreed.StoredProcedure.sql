USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_DeletePetBreed]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_DeletePetBreed]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_DeletePetBreed]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_DeletePetBreed]
	@ID uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;

	DELETE PetBreed
	WHERE ID = @ID

END
GO
