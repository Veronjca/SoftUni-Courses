SELECT [DepartmentID], [Salary] 
	FROM (SELECT [DepartmentID],
	[Salary],
	DENSE_RANK() OVER (PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [Rank]
	FROM [Employees]) AS [Ranked]
	WHERE [Rank] = 3
	GROUP BY [DepartmentID], [Salary]

	
