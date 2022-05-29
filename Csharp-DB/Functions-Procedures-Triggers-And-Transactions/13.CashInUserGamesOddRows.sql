CREATE FUNCTION ufn_CashInUsersGames (@gameName NVARCHAR(MAX))
RETURNS TABLE
AS
RETURN
		SELECT SUM([Cash]) AS [SumCash] FROM (SELECT [Cash] FROM
		(SELECT TOP(100) *, ROW_NUMBER() OVER(ORDER BY [Cash] DESC) AS [RowNumber]
		FROM [UsersGames] 
		WHERE [GameId] IN (SELECT [Id] FROM [Games] WHERE [Name] = @gameName)) AS x
		WHERE [RowNumber] % 2 != 0) AS y		


