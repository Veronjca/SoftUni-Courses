SELECT TOP(20)
	fd.Id,
	fd.[Start],
	p.FullName,
	a.AirportName,
	fd.TicketPrice
		FROM FlightDestinations AS fd
		JOIN Passengers AS p ON fd.PassengerId = p.Id
		JOIN Airports AS a ON fd.AirportId = a.Id
		WHERE DAY(Start) % 2 = 0
		ORDER BY fd.TicketPrice DESC, a.AirportName