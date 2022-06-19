CREATE OR ALTER PROC  usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	DECLARE @ownerId INT = (SELECT OwnerId FROM Animals WHERE [Name] = @AnimalName)

	IF(@ownerId IS NULL)
		BEGIN
			SELECT 
			[Name],
			'For adoption' AS OwnersName
			FROM Animals
				WHERE [Name] = @AnimalName
		END
	ELSE
		BEGIN
		SELECT 
			a.[Name],
			o.[Name] AS OwnersName
			FROM Animals AS a 
			JOIN Owners AS o ON a.OwnerId = o.Id
			WHERE a.[Name] = @AnimalName
		END
END