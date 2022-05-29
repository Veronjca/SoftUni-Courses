CREATE PROCEDURE usp_GetTownsStartingWith @Name NVARCHAR(MAX)
AS
BEGIN
	SELECT [Name] FROM [Towns] WHERE [Name] LIKE @Name + '%'
END

