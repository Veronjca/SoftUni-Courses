SELECT TOP(10) a.[FirstName], a.[LastName], a.[DepartmentID] 
	FROM [Employees] AS a
	WHERE [Salary] > (SELECT AVG([Salary])
	FROM [Employees] b
	WHERE b.[DepartmentID] = a.[DepartmentID]
	GROUP BY [DepartmentID]) 
	ORDER BY [DepartmentID]

