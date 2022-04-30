CREATE TABLE [Students]
(
	[StudentID] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Exams]
(
	[ExamID] INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL
)

CREATE TABLE [StudentsExams]
(
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[ExamID] INT REFERENCES [Exams]([ExamID])
	PRIMARY KEY([StudentID], [ExamID])
)

INSERT INTO [Students] VALUES
('Mila'),
('Toni'),
('Ron')

INSERT INTO [Exams] VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

INSERT INTO [StudentsExams] VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)
