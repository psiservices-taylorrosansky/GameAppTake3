CREATE PROCEDURE [dbo].[AddGame]
	@Name VARCHAR(50),
	@ReleaseDate DATETIME(7) = NULL,
	@Developer VARCHAR(50)
AS
BEGIN
	INSERT INTO GamesTable(Name, ReleaseDate, Developer)
	VALUES(@Name, @RelaseDate, @Developer)
END