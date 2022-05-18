SELECT *
INTO #Filtered
FROM [Employees]
WHERE [Salary] > 30000

DELETE FROM #Filtered
WHERE [ManagerID] = 42

UPDATE #Filtered SET [Salary] = [Salary] + 5000
WHERE [DepartmentID] = 1

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary]
	FROM #Filtered
	GROUP BY [DepartmentID]


