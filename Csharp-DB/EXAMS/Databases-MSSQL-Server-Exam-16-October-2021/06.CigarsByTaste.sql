SELECT 
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
		FROM Cigars AS c
		JOIN Tastes AS t ON t.Id = c.TastId
		WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
		ORDER BY c.PriceForSingleCigar DESC