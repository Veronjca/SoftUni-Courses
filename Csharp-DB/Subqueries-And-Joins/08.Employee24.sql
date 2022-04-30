SELECT e.[EmployeeID], e.[FirstName], [ProjectName] =
	CASE
	WHEN DATEPART(YEAR, p.[StartDate]) >= 2005 THEN NULL
	ELSE p.[Name]
	END
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON ep.[EmployeeID] = e.[EmployeeID]
	JOIN [Projects] AS p ON ep.[ProjectID] = p.[ProjectID]
	WHERE e.[EmployeeID] = 24


