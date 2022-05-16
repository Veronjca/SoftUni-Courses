SELECT [DepositGroup], [TotalSum] FROM (SELECT [DepositGroup], 
	[MagicWandCreator], 
	SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]) a
	WHERE [MagicWandCreator] = 'Ollivander family' AND [TotalSum] < 150000
	ORDER BY [TotalSum] DESC



