SELECT * FROM (SELECT c.[ContinentCode], c.[CurrencyCode], 
	COUNT([CurrencyCode]) AS [CurrencyUsage]
	FROM [Countries] AS c
	GROUP BY c.[ContinentCode], c.[CurrencyCode]) AS x
	WHERE [CurrencyUsage] NOT IN(1,0)


	