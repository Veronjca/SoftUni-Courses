CREATE TABLE [Majors]
(
	[MajorID] INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Students]
(
	[StudentID] INT IDENTITY PRIMARY KEY,
	[StudentNumber] NVARCHAR(50) NOT NULL,
	[StudentName] NVARCHAR(50) NOT NULL,
	[MajorID] INT REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments]
(
	[PaymentID] INT IDENTITY PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] MONEY,
	[StudentID] INT REFERENCES [Students]([StudentID])
)

CREATE TABLE [Subjects]
(
	[SubjectID] INT IDENTITY PRIMARY KEY,
	[SubjectName] NVARCHAR(50) NOT NULL
)

CREATE TABLE [Agenda]
(
	[StudentID] INT REFERENCES [Students]([StudentID]),
	[SubjectID] INT REFERENCES [Subjects]([SubjectID])
	PRIMARY KEY([StudentID], [SubjectID])
)