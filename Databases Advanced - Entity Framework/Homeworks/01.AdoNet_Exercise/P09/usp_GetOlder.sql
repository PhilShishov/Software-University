USE [MinionsDB]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetOlder]    Script Date: 3/26/2022 8:21:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_GetOlder] 
	@id int
AS
BEGIN
	
	UPDATE Minions SET Age = Age+1 WHERE Id = @id
END