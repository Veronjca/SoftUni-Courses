SELECT 
	[Name],
	PhoneNumber,
	SUBSTRING([Address], CHARINDEX(',', [Address]) + 1, LEN([Address])) AS Address
	FROM Volunteers
		WHERE DepartmentId = (SELECT Id FROM VolunteersDepartments WHERE DepartmentName = 'Education program assistant')
		AND [Address] LIKE '%Sofia%'
		ORDER BY [Name]