CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
BEGIN
	SELECT [FirstName], [LastName] FROM [AccountHolders] WHERE [Id] IN (SELECT [AccountHolderId] 
		FROM [Accounts]		
		GROUP BY [AccountHolderId] 
		HAVING SUM([Balance]) > @number)
	ORDER BY [FirstName], [LastName]	
END