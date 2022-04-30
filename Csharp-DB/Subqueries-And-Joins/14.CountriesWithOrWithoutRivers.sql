SELECT TOP(5) c.[CountryName], r.[RiverName]
	FROM [Countries] AS c
	LEFT JOIN [Continents] AS cs ON c.[ContinentCode] = cs.[ContinentCode]
	LEFT JOIN [CountriesRivers] AS cr ON cr.[CountryCode] = c.[CountryCode]
	LEFT JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
	WHERE cs.[ContinentName] = 'Africa'
	ORDER BY c.[CountryName]