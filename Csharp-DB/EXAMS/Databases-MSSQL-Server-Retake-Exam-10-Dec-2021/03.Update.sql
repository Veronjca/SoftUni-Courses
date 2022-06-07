UPDATE Aircraft
	SET Condition = 'A'
		WHERE Condition IN ('C', 'B')
		AND (FlightHours IS NULL OR FlightHours BETWEEN 0 AND 100)
		AND Year >= 2013