SELECT 
	p.FullName,
	COUNT(*) AS CountOfAircraft,
	SUM(fd.TicketPrice) AS TotalPayed
		FROM FlightDestinations AS fd
		JOIN Passengers AS p ON fd.PassengerId = p.Id
		GROUP BY PassengerId, p.FullName
		HAVING COUNT(*)	> 1 AND SUBSTRING(p.FullName, 2, 1) = 'a'
		ORDER BY p.FullName

