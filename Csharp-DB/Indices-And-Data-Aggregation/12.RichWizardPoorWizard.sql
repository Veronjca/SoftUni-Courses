SELECT SUM([Difference]) AS [SumDifference] 
		FROM (
		SELECT 
		[DepositAmount] - LEAD([DepositAmount]) OVER (ORDER BY Id) AS [Difference]      
FROM   [WizzardDeposits]) AS a
