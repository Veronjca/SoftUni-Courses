SELECT COUNT([CountryName]) AS [Count] 
	FROM (SELECT c.[CountryName] 
			FROM [MountainsCountries] AS mc
			RIGHT JOIN [Countries] AS c ON c.[CountryCode] = mc.[CountryCode] 
			WHERE mc.[CountryCode] IS NULL) AS a