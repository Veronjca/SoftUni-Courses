CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(6,2), @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(8,4)
AS
BEGIN
	DECLARE @futureValueOfTheInitialSum DECIMAL(8,4) = @initialSum * (POWER(1 + @yearlyInterestRate, @numberOfYears));
	RETURN ROUND(@futureValueOfTheInitialSum, 4);
END

DECLARE @TEST DECIMAL(8,4) = dbo.ufn_CalculateFutureValue (1000, 0.1, 5)
SELECT @TEST