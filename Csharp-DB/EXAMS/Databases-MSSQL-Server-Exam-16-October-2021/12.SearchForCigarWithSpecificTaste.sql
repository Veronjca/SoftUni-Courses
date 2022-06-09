CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT 
		c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Cigars AS c
		JOIN Tastes AS t ON t.Id = c.TastId
		JOIN Sizes AS s ON s.Id = c.SizeId
		JOIN Brands AS b ON b.Id = c.BrandId
		WHERE t.TasteType = @taste
		ORDER BY s.[Length], s.RingRange DESC
END
