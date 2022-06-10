SELECT 
	CONCAT_WS(' ', e.FirstName, e.LastName) AS FullName,
	(SELECT DISTINCT COUNT(UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount	
	FROM Employees AS e
	GROUP BY e.FirstName, e.LastName, e.Id
	ORDER BY UsersCount DESC, FullName

