SELECT 
	u.Username,
	c.[Name] AS CategoryName
		FROM Reports AS r
		JOIN Users AS u ON r.UserId = u.Id
		JOIN Categories AS c ON c.Id = r.CategoryId
		WHERE CONCAT_WS('-', MONTH(r.OpenDate), DAY(r.OpenDate)) = CONCAT_WS('-', MONTH(u.Birthdate), DAY(u.Birthdate))
		ORDER BY u.Username, c.[Name]
		
