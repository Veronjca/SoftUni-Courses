CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
	DECLARE @projectsCount INT = (SELECT COUNT(*) FROM [EmployeesProjects] WHERE [EmployeeID] = @emloyeeId);

	INSERT INTO [EmployeesProjects] ([EmployeeID], [ProjectID]) VALUES
		 (@emloyeeId, @projectID)

	IF @projectsCount >= 3
		BEGIN
			ROLLBACK;
			THROW 50000, 'The employee has too many projects!', 1;  		
		END
END