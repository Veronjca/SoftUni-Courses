SELECT c.[CountryCode], m.[MountainRange], p.[PeakName], p.[Elevation] 
	FROM [MountainsCountries] AS mc
	JOIN [Mountains] AS m ON mc.[MountainId] = m.[Id]
	JOIN [Countries] AS c ON mc.[CountryCode] = c.[CountryCode]
	JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
	WHERE p.[Elevation] > 2835 AND c.[CountryCode] = 'BG'
	ORDER BY p.[Elevation] DESC
