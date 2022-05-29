CREATE PROC usp_CalculateFutureValueForAccount (@accountID INT, @yearlyInterestRate FLOAT)
AS
BEGIN
	SELECT a.[Id] AS [Account Id],
		[FirstName] AS [First Name], 
		[LastName] AS [Last Name], 
		a.[Balance] AS [Current Balance],
		dbo.ufn_CalculateFutureValue (a.[Balance], @yearlyInterestRate, 5) AS [Balance in 5 years]
		FROM [AccountHolders] AS ah
		JOIN [Accounts] AS a ON a.[AccountHolderId] = ah.[Id]
		WHERE a.[Id] = @accountID
END