SELECT [ContinentCode], 
	[CurrencyCode], 
	[CurrencyUsage] 
	FROM (SELECT [ContinentCode], 
	[CurrencyCode],
	[CurrencyUsage],
	DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY [CurrencyUsage] DESC) AS [Rank]
	FROM (SELECT [ContinentCode], 
	[CurrencyCode], 
	COUNT([CurrencyCode]) AS [CurrencyUsage]
	FROM [Countries]
	GROUP BY [ContinentCode], [CurrencyCode]) AS a) AS b
	WHERE [CurrencyUsage] NOT IN (1,0) AND [Rank] = 1

 


	