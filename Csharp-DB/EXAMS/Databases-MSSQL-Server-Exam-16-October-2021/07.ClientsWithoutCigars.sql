SELECT 
	Id,
	CONCAT_WS(' ', FirstName, LastName) AS ClientName,
	Email
	FROM Clients
	WHERE Id NOT IN (SELECT ClientId FROM ClientsCigars)
	ORDER BY ClientName