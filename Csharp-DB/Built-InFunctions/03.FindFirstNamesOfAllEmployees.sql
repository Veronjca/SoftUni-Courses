SELECT [FirstName]
	FROM [Employees]
	WHERE [DepartmentID] = 3 OR [DepartmentID] = 10
	AND DATEPART(year, [HireDate]) >= 1995 AND DATEPART(year, [HireDate]) <= 2005