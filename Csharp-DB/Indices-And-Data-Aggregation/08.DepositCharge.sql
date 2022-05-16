SELECT [DepositGroup],
	[MagicWandCreator],
	MIN([DepositCharge]) AS [MinDepositCharge]
	FROM [WizzardDeposits]
	GROUP BY [DepositGroup], [MagicWandCreator]
	ORDER BY [MagicWandCreator], [DepositGroup]