SELECT 
	CigarName,
	PriceForSingleCigar,
	ImageURL
		FROM Cigars
		ORDER BY PriceForSingleCigar, CigarName DESC
