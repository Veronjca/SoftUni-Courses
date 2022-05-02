SELECT TOP(5) [Country], [Highest Peak Name], [Highest Peak Elevation], [Mountain]
	FROM (SELECT [CountryName] AS [Country], 
	ISNULL(p.[PeakName], '(no highest peak)') AS [Highest Peak Name],
	ISNULL(p.[Elevation], 0) AS [Highest Peak Elevation],
	ISNULL(m.[MountainRange], '(no mountain)') AS [Mountain],
	DENSE_RANK() OVER (PARTITION BY [CountryName] ORDER BY [Elevation] DESC) AS [Rank]
	FROM [Peaks] AS p
	RIGHT JOIN [Mountains] AS m ON p.[MountainId] = m.[Id] 
	RIGHT JOIN [MountainsCountries] AS mc ON m.[Id] = mc.[MountainId]
	RIGHT JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode]) AS x
	WHERE [Rank] = 1
	ORDER BY [Country], [Highest Peak Name]