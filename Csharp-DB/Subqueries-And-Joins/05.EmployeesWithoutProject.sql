SELECT TOP(3) e.[EmployeeID], e.[FirstName] 
	FROM [Employees] AS e
	LEFT JOIN [EmployeesProjects] AS ep ON e.[EmployeeID] = ep.[EmployeeID]
	WHERE e.[EmployeeID] NOT IN (SELECT [EmployeeID] FROM [EmployeesProjects])
	ORDER BY e.[EmployeeID]
	