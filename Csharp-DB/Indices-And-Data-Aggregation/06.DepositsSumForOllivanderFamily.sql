SELECT [DepositGroup], [TotalSum] FROM (SELECT [DepositGroup], 
	[MagicWandCreator], 
	SUM([DepositAmount]) AS [TotalSum]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]) a
	WHERE [MagicWandCreator] = 'Ollivander family'