SELECT	
	fd.AircraftId,
	a.Manufacturer,
	a.FlightHours,
	COUNT(*) AS FlightDestinationsCount,
	ROUND(AVG(TicketPrice),2) as AvgPrice
	FROM FlightDestinations AS fd
	JOIN Aircraft AS a ON fd.AircraftId = a.Id
	GROUP BY AircraftId, a.Manufacturer, a.FlightHours
	HAVING COUNT(*) >= 2
	ORDER BY COUNT(*) DESC, AircraftId