SELECT SUBSTRING([FirstName], 1,1) AS [FisrtLetter]
	FROM [WizzardDeposits]
	GROUP BY SUBSTRING([FirstName], 1,1), [DepositGroup]
	HAVING [DepositGroup] = 'Troll Chest' 
