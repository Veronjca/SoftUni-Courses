CREATE TABLE [Users]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	[LastLoginTime] TIME,
	[IsDeleted] BIT,
)
INSERT INTO [Users] VALUES
('Vikity', 'nvm2', NULL, NULL, 0),
('Paf', 'napOshalka', NULL, NULL, 0),
('Emre', 'qkonaposhenbrat', NULL, NULL, 1),
('Mushu', 'mushu3', NULL, NULL, 0),
('Maxi', 'maxicosi', NULL, NULL, 0)
