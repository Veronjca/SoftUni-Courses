SELECT [TownID], [Name]
	FROM [Towns]
	WHERE [Name] LIKE 'M%' 
	OR [Name] LIKE 'K%'
	OR [Name] LIKE 'B%'
	OR [Name] LIKE 'E%'
	ORDER BY [Name]