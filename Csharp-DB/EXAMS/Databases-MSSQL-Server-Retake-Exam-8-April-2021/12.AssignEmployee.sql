CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	DECLARE @categoryDepartmentId INT = (SELECT 
											c.DepartmentId 
											FROM Reports AS r 
											JOIN Categories AS c ON c.Id = r.CategoryId 
											WHERE r.Id = @ReportId)
	DECLARE @employeeDepartmentId INT = (SELECT 
											d.Id 
											FROM Employees AS e 
											JOIN Departments AS d ON d.Id = e.DepartmentId 
											WHERE e.Id = @EmployeeId)
	
	IF (@categoryDepartmentId != @employeeDepartmentId)
		THROW 51000, 'Employee doesn''t belong to the appropriate department!', 1; 
	ELSE
		BEGIN
			UPDATE Reports
				SET EmployeeId = @EmployeeId
				WHERE Id = @ReportId
		END
END
