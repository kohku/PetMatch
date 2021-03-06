USE [PetMatchStorage]
GO

/****** Object:  StoredProcedure [dbo].[usp_GetProvinces]    Script Date: 05/07/2014 17:45:59 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[usp_GetProvinces]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [dbo].[usp_GetProvinces]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[usp_GetProvinces]
	@ID uniqueidentifier = NULL,
	@StateID uniqueidentifier = NULL,
	@Name nvarchar(100) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM Province
	WHERE (@ID IS NULL OR ID = @ID)
		AND (@StateID IS NULL OR StateID LIKE @StateID)
		AND (@Name IS NULL OR Name LIKE @Name)
	ORDER BY Name

END
GO
