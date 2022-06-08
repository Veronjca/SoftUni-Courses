SELECT 
	a.AirportName,
	fd.[Start] AS DayTime,
	fd.TicketPrice,
	p.FullName,
	ar.Manufacturer,
	ar.Model
		FROM FlightDestinations AS fd
		JOIN Airports AS a ON a.Id = fd.AirportId
		JOIN Passengers AS p ON p.Id = fd.PassengerId
		JOIN Aircraft as ar ON ar.Id = fd.AircraftId
		WHERE DATEPART(HOUR, Start) BETWEEN 6 AND 20
		AND TicketPrice > 2500
		ORDER BY ar.Model
