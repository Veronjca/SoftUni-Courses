SELECT 
	c.LastName,
	AVG(s.[Length]) AS CiagrLength,
	CEILING(AVG(s.RingRange)) AS CiagrRingRange
		FROM Clients AS c			
		JOIN ClientsCigars AS cc ON cc.ClientId = c.Id
		JOIN Cigars AS cg ON cg.Id = cc.CigarId
		JOIN Sizes AS s ON s.Id = cg.SizeId
		WHERE c.Id IN (SELECT DISTINCT [ClientId] FROM ClientsCigars)	
		GROUP BY  c.LastName
		ORDER BY AVG(s.[Length]) DESC
	

