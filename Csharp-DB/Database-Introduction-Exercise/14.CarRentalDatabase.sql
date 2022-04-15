CREATE TABLE [Categories]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[CategoryName] NVARCHAR(30) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
)
CREATE TABLE [Cars]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[PlateNumber] NVARCHAR(8) NOT NULL,
	[Manufacturer] NVARCHAR(20) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES[Categories]([Id]),
	[Doors] INT,
	[Picture] VARBINARY,
	[Condition] NVARCHAR(10),
	[Available] BIT NOT NULL
)
CREATE TABLE [Employees]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] NVARCHAR(MAX) NOT NULL,
	[LastName] NVARCHAR(MAX) NOT NULL,
	[Title] NVARCHAR(MAX),
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [Customers]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[DriverLicenceNumber] NVARCHAR(8) NOT NULL,
	[FullName] NVARCHAR(MAX) NOT NULL,
	[Address] NVARCHAR(MAX),
	[City] NVARCHAR(MAX),
	[ZIPCode] INT,
	[Notes] NVARCHAR(MAX)
)
CREATE TABLE [RentalOrders]
(
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES[Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES[Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES[Cars]([Id]),
	[TankLevel] DECIMAL(5,2) NOT NULL,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2 ,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplied] INT,
	[TaxRate] INT,
	[OrderStatus] NVARCHAR(MAX) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Categories] VALUES
('Crossover', NULL, NULL, NULL, NULL),
('Coupe', NULL, NULL, NULL, NULL),
('Sports Car', NULL, NULL, NULL, NULL)
INSERT INTO [Cars] VALUES
('СА7321ВН', 'Porsche', 'Cayenne', 2019, 3, NULL, NULL, NULL, 1),
('СВ2338ЕА', 'Honda', 'CR-V', 2022, 1, NULL, NULL, NULL, 1),
('ВН1829ВР', 'Toyota', 'Supra', 2022, 2, NULL, NULL, NULL, 0)
INSERT INTO [Employees] VALUES
('Pavlin', 'Penev', NULL, NULL),
('Emre', 'Djebir', NULL, NULL),
('Ivan', 'Mitowski', NULL, NULL)
INSERT INTO [Customers] VALUES
('T7000TT', 'Veronica Goranova', NULL, NULL, NULL, NULL),
('CA2222CA', 'Maxim Dimitrov', NULL, NULL, NULL, NULL),
('C9396HP', 'Martin Dimitrov', NULL, NULL, NULL, NULL)
INSERT INTO [RentalOrders] VALUES
(3, 2, 1, 100.5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'ONHOLD', NULL),
(2, 1, 3 , 105.5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'ACTIVE', NULL),
(1, 3, 2 , 105.6, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'ACTIVE', NULL)

