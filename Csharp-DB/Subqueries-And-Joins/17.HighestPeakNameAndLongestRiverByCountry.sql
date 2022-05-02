SELECT TOP(5) c.[CountryName],
	MAX([Elevation]) AS [HighestPeakElevation],
	MAX([Length]) AS [LongestRiverLength]
	FROM [Peaks] AS p
	LEFT JOIN [Mountains] AS m ON p.[MountainId] = m.[Id] 
	LEFT JOIN [MountainsCountries] AS mc ON m.[Id] = mc.[MountainId]
	LEFT JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode]
	LEFT JOIN [CountriesRivers] AS cr ON cr.[CountryCode] = c.[CountryCode]
	LEFT JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
	GROUP BY c.[CountryName]
	ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, [CountryName]