CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @Count INT = (SELECT COUNT(*)
		FROM FlightDestinations AS fd
		JOIN Passengers AS p ON p.Id = fd.PassengerId
		WHERE p.Email = @email)
	RETURN @Count;
END

