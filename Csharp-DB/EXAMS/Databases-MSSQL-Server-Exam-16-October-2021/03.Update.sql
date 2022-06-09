UPDATE Cigars
	SET PriceForSingleCigar += PriceForSingleCigar * 0.2
	FROM Cigars AS c
	JOIN Tastes AS t ON t.Id = c.TastId
	WHERE t.TasteType = 'Spicy'

UPDATE Brands
	SET BrandDescription = 'New description'
	WHERE BrandDescription IS NULL