SELECT 
	p.FirstName,
	p.LastName,
	a.Manufacturer,
	a.Model,
	a.FlightHours
		FROM PilotsAircraft AS pa
		JOIN Pilots AS p ON pa.PilotId = p.Id
		JOIN Aircraft AS a ON pa.AircraftId = a.Id
		WHERE a.FlightHours <= 304
		ORDER BY a.FlightHours DESC, p.FirstName
	