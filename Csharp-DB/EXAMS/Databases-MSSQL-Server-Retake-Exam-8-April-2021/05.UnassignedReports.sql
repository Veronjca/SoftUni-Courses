SELECT 
	[Description],
	CONCAT_WS('-', FORMAT(OpenDate, 'dd'), FORMAT(OpenDate, 'MM'), YEAR(OpenDate)) AS OpenDate
	FROM Reports AS r
	WHERE EmployeeId IS NULL
	ORDER BY r.OpenDate, [Description]