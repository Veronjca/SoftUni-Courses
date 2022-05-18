SELECT COUNT(*) AS [Count] 
	FROM (SELECT * 
	FROM [Employees]
	WHERE [ManagerID] IS NULL) AS A