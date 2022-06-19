ALTER TABLE Volunteers
	ALTER COLUMN DepartmentId INT 

UPDATE Volunteers
	SET DepartmentId = NULL
	WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')

DELETE FROM VolunteersDepartments
	WHERE DepartmentName = 'Education program assistant'