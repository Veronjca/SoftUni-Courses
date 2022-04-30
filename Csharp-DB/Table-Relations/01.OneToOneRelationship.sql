CREATE TABLE [Passports]
(
	[PassportID] INT IDENTITY(101,1) PRIMARY KEY,
	[PassportNumber] NVARCHAR(50) NOT NULL
)
CREATE TABLE [Persons]
(
	[PersonID] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL, 
	[Salary] MONEY,
	[PassportID] INT REFERENCES [Passports]([PassportID])
)	

INSERT INTO [Passports] VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

INSERT INTO [Persons] VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

