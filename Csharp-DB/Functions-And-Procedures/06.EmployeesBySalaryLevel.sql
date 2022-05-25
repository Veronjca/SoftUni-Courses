CREATE OR ALTER PROCEDURE usp_EmployeesBySalaryLevel @SalaryLevel NVARCHAR(10)
AS
BEGIN
	SELECT [FirstName], [LastName] 
		FROM [Employees]
		WHERE @SalaryLevel = dbo.ufn_GetSalaryLevel([Salary])
END 
