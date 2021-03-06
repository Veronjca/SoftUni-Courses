--CREATE DATABASE [Airport]

CREATE TABLE Passengers
(
	Id INT IDENTITY PRIMARY KEY,
	FullName VARCHAR(100) UNIQUE NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(30) UNIQUE NOT NULL,
	LastName VARCHAR(30) UNIQUE  NOT NULL,
	Age TINYINT CHECK (Age BETWEEN 21 AND 62) NOT NULL,
	Rating FLOAT CHECK (Rating BETWEEN 0 AND 10)
)

CREATE TABLE AircraftTypes
(
	Id INT IDENTITY PRIMARY KEY,
	TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
	Id INT IDENTITY PRIMARY KEY,
	Manufacturer VARCHAR(25) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	FlightHours INT,
	Condition CHAR(1) NOT NULL,
	TypeId INT REFERENCES AircraftTypes(Id) NOT NULL

)

CREATE TABLE PilotsAircraft
(
	AircraftId INT REFERENCES Aircraft(Id) NOT NULL,
	PilotId INT REFERENCES Pilots(Id) NOT NULL,
	PRIMARY KEY (AircraftId, PilotId)
)

CREATE TABLE Airports
(
	Id INT IDENTITY PRIMARY KEY,
	AirportName VARCHAR(70) UNIQUE NOT NULL,
	Country VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE FlightDestinations
(
	Id INT IDENTITY PRIMARY KEY,
	AirportId INT REFERENCES Airports(Id) NOT NULL,
	[Start] DATETIME NOT NULL,
	AircraftId INT REFERENCES Aircraft(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL

)