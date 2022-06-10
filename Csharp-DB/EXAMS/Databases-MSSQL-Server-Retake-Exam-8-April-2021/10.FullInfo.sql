SELECT 
	CASE
	WHEN e.FirstName IS NULL OR e.LastName IS NULL THEN 'None'
	ELSE CONCAT_WS(' ', e.FirstName, e.LastName)
	END AS Employee, 
	ISNULL(d.[Name], 'None') AS Department,
	ISNULL(c.[Name], 'None') AS Category,
	ISNULL(r.[Description], 'None') AS [Description],
	CASE
	 WHEN r.OpenDate IS NULL THEN 'None'
	 ELSE CONCAT_WS('.', FORMAT(r.OpenDate, 'dd'), FORMAT(r.OpenDate, 'MM'), YEAR(r.OpenDate))
	END AS OpenDate,
	ISNULL(s.[Label], 'None') AS [Status],
	ISNULL(u.[Name], 'None') AS [User]
		FROM Reports AS r
		LEFT JOIN Employees AS e ON  e.Id = r.EmployeeId
		LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
		LEFT JOIN Categories AS c ON c.Id = r.CategoryId
		LEFT JOIN [Status] AS s ON s.Id = r.StatusId
		LEFT JOIN Users AS u ON u.Id = r.UserId
		ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, [Description], r.OpenDate, s.[Label], u.[Name] 
