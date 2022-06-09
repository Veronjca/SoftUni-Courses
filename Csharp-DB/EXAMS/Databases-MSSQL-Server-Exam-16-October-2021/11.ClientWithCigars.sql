CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @clientId INT = (SELECT Id FROM Clients WHERE FirstName = @name)
	DECLARE @count INT = (SELECT COUNT(*) FROM ClientsCigars WHERE ClientId = @clientId)
	RETURN @count;
END