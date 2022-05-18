SELECT [DepartmentID], [MaxSalary] FROM (SELECT 
	[DepartmentID], 
	MAX([Salary]) AS [MaxSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]) AS [MaxSalaries]
	WHERE [MaxSalary] NOT BETWEEN 30000 AND 70000