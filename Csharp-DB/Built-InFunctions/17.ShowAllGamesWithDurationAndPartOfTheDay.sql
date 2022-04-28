SELECT [Name] , [Part of the Day] = 
	CASE 
	WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
	ELSE 'Evening'
	END,
	[Duration] = 
	CASE
	WHEN [Duration] <= 3 THEN 'Extra Short'
	WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
	WHEN [Duration] > 6 THEN 'Long'
	ELSE 'Extra Long'
	END
	FROM [Games]
	ORDER BY [Name], [Duration], [Part of the Day]