CREATE DATABASE [Movies]
CREATE TABLE [Directors]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[DirectorName] NVARCHAR(26) NOT NULL,
	[Notes] NVARCHAR(MAX),
)
CREATE TABLE [Genres]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[GenreName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)
CREATE TABLE [Categories]
(
    [Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX),
)
CREATE TABLE [Movies]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] INT NOT NULL,
	[Length] TIME,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] DECIMAL(4,2),
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Directors] VALUES
('Veronica', NULL),
('Pavlin', NULL),
('Martin', NULL),
('Emre', NULL),
('Maxim', NULL)
INSERT INTO [Genres] VALUES
('Sci-Fi', NULL),
('Action', NULL),
('Drama', NULL),
('Romance', NULL),
('Horror', NULL)
INSERT INTO [Categories] VALUES
('Sci-Fi', NULL),
('Action', NULL),
('Drama', NULL),
('Romance', NULL),
('Horror', NULL)
INSERT INTO [Movies] VALUES
('The fault in our stars', 1, 2014, NULL, 4, 4, 10.0, NULL),
('Star Wars', 2, 2000, NULL, 1, 1, 5.5, NULL),
('The Notebook', 3, 2004, NULL, 3, 3, 9.5, NULL),
('Fast and Furious', 4, 2007, NULL, 2, 2, 6.6, NULL),
('Worng Turn', 5, 2005, NULL, 5, 5, 3.0, NULL)
	
