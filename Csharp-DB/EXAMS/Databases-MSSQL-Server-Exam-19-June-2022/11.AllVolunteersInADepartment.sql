CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
		DECLARE @count INT = (SELECT COUNT(*) 
									FROM Volunteers 
									WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = @VolunteersDepartment))
		RETURN @count;
END