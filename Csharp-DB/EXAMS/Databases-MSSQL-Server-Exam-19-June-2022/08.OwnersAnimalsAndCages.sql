SELECT 
	CONCAT_WS('-', o.[Name], a.[Name]) AS OwnersAnimals,
	o.PhoneNumber,
	ac.CageId AS CageId
	FROM Animals AS a
		JOIN Owners AS o ON o.Id = a.OwnerId
		JOIN AnimalTypes AS [at] ON [at].Id = a.AnimalTypeId 
		JOIN AnimalsCages AS ac ON ac.AnimalId = a.Id
		WHERE [at].AnimalType = 'Mammals'
		ORDER BY o.[Name], a.[Name] DESC