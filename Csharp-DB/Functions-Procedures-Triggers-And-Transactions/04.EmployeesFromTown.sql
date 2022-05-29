CREATE OR ALTER PROCEDURE usp_GetEmployeesFromTown @TownName NVARCHAR(MAX)
AS
BEGIN
	SELECT e.[FirstName], e.[LastName]
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON e.[AddressID] = a.[AddressID]
	JOIN [Towns] AS t ON a.[TownID] = t.[TownID]
	WHERE t.[Name] = @TownName
END
