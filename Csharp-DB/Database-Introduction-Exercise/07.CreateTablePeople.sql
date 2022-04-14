CREATE TABLE [People]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	[Gender] CHAR(1) NOT NULL,
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)
INSERT INTO [People] VALUES
('Viki', NULL, 1.67, 63, 'f', '1998-01-12', 'very good lad'),
('Paf', NULL, 1.75, 75, 'm', '1990-11-23', 'exercise slayer'),
('Emre', NULL, 1.73, 79, 'm', '2000-05-07', 'qko naposhen'),
('Mushu', NULL, 1.87, 102, 'm', '1996-02-05', 'love mushu'),
('Maxi', NULL, 0.75, 10, 'm', '2021-06-27', 'love mini mushu')
