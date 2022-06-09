DELETE FROM Clients
	WHERE AddressId IN (SELECT Id FROM Addresses WHERE SUBSTRING(Country, 1, 1) = 'C')

DELETE FROM Addresses
	WHERE SUBSTRING(Country, 1, 1) = 'C'