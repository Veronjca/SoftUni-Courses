CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN 
	IF @salary < 30000
		RETURN 'Low';
	ELSE IF @salary BETWEEN 30000 AND 50000
		BEGIN
			RETURN 'Average'
		END
		RETURN 'High'
END