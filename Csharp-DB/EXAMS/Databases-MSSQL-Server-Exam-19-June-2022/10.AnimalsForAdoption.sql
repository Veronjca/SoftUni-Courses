SELECT 
	a.[Name],
	YEAR(a.BirthDate),
	[at].AnimalType
	FROM Animals AS a
	JOIN AnimalTypes AS [at] ON a.AnimalTypeId = [at].Id
	WHERE OwnerId IS NULL 
	AND [at].AnimalType != 'Birds'
	AND DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5
	ORDER BY a.[Name]