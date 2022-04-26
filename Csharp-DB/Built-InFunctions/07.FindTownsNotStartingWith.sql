SELECT [TownID], [Name]
	FROM [Towns]
	WHERE NOT ([Name] LIKE 'R%') 	
	AND NOT ([Name] LIKE 'B%') 	
	AND NOT ([Name] LIKE 'D%') 	
	ORDER BY [Name] 