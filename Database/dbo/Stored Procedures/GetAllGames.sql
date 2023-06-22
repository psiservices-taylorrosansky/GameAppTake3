CREATE PROCEDURE [dbo].[GetAllGames]
AS
BEGIN
    SELECT Id, Name, ReleaseDate, Developer
    FROM dbo.Games
END
GO