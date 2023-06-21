CREATE PROCEDURE [dbo].[GetAllProducts]
AS
BEGIN
    SELECT Id, Name, ReleaseDate, Developer
    FROM dbo.Games
END
GO