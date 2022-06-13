using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ADO.NET
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionStringToMaster = "Server=localhost;Database=master;User=sa;Password=A3047744;Trusted_Connection=False;MultipleActiveResultSets=False;Encrypt=False";

            SqlConnection connectionToMaster = new SqlConnection(connectionStringToMaster);
            await connectionToMaster.OpenAsync();

            await using (connectionToMaster)
            {
                string createCommandString = "CREATE DATABASE MinionsDB";
                SqlCommand command = new SqlCommand(createCommandString, connectionToMaster);
                await command.ExecuteNonQueryAsync();
            }

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string createTableCountriesQuery = "CREATE TABLE Countries (Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50))";
                SqlCommand commandCreateCountriesTable = new SqlCommand(createTableCountriesQuery, connectionToMinionsDB);
                await commandCreateCountriesTable.ExecuteNonQueryAsync();

                string createTableTownsQuery = "CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))";
                SqlCommand commandCreateTownsTable = new SqlCommand(createTableTownsQuery, connectionToMinionsDB);
                await commandCreateTownsTable.ExecuteNonQueryAsync();

                string createTableMinionsQuery = "CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY,Name VARCHAR(30), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))";
                SqlCommand commandCreateMinionsTable = new SqlCommand(createTableMinionsQuery, connectionToMinionsDB);
                await commandCreateMinionsTable.ExecuteNonQueryAsync();

                string createTableEvilnessFactorsQuery = "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50))";
                SqlCommand commandCreateEvilnessFactorsTable = new SqlCommand(createTableEvilnessFactorsQuery, connectionToMinionsDB);
                await commandCreateEvilnessFactorsTable.ExecuteNonQueryAsync();

                string createTableVillainsQuery = "CREATE TABLE Villains (Id INT PRIMARY KEY IDENTITY, Name VARCHAR(50), EvilnessFactorId INT FOREIGN KEY REFERENCES EvilnessFactors(Id))";
                SqlCommand commandCreateVillainsTable = new SqlCommand(createTableVillainsQuery, connectionToMinionsDB);
                await commandCreateVillainsTable.ExecuteNonQueryAsync();

                string createTableMinionsVillainsQuery = "CREATE TABLE MinionsVillains (MinionId INT FOREIGN KEY REFERENCES Minions(Id),VillainId INT FOREIGN KEY REFERENCES Villains(Id),CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId))";
                SqlCommand commandCreateMinionsVillainsTable = new SqlCommand(createTableMinionsVillainsQuery, connectionToMinionsDB);
                await commandCreateMinionsVillainsTable.ExecuteNonQueryAsync();

                string insertIntoCountriesQuery = "INSERT INTO Countries ([Name]) VALUES ('Bulgaria'),('England'),('Cyprus'),('Germany'),('Norway')";
                SqlCommand commandInsertIntoCountries = new SqlCommand(insertIntoCountriesQuery, connectionToMinionsDB);
                await commandInsertIntoCountries.ExecuteNonQueryAsync();

                string insertIntoTownsQuery = "INSERT INTO Towns ([Name], CountryCode) VALUES ('Plovdiv', 1),('Varna', 1),('Burgas', 1),('Sofia', 1),('London', 2),('Southampton', 2),('Bath', 2),('Liverpool', 2),('Berlin', 3),('Frankfurt', 3),('Oslo', 4)";
                SqlCommand commandInsertIntoTowns = new SqlCommand(insertIntoTownsQuery, connectionToMinionsDB);
                await commandInsertIntoTowns.ExecuteNonQueryAsync();

                string insertIntoMinionsQuery = "INSERT INTO Minions (Name,Age, TownId) VALUES('Bob', 42, 3),('Kevin', 1, 1),('Bob ', 32, 6),('Simon', 45, 3),('Cathleen', 11, 2),('Carry ', 50, 10),('Becky', 125, 5),('Mars', 21, 1),('Misho', 5, 10),('Zoe', 125, 5),('Json', 21, 1)";
                SqlCommand commandInsertIntoMinions = new SqlCommand(insertIntoMinionsQuery, connectionToMinionsDB);
                await commandInsertIntoMinions.ExecuteNonQueryAsync();

                string insertIntoEvilnessFactorsQuery = "INSERT INTO EvilnessFactors (Name) VALUES ('Super good'),('Good'),('Bad'), ('Evil'),('Super evil')";
                SqlCommand commandInsertIntoEvilnessFactors = new SqlCommand(insertIntoEvilnessFactorsQuery, connectionToMinionsDB);
                await commandInsertIntoEvilnessFactors.ExecuteNonQueryAsync();

                string insertIntoVillainsQuery = "INSERT INTO Villains (Name, EvilnessFactorId) VALUES ('Gru',2),('Victor',1),('Jilly',3),('Miro',4),('Rosen',5),('Dimityr',1),('Dobromir',2)";
                SqlCommand commandInsertIntoVillains = new SqlCommand(insertIntoVillainsQuery, connectionToMinionsDB);
                await commandInsertIntoVillains.ExecuteNonQueryAsync();

                string insertIntoMinionsVillainsQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (4,2),(1,1),(5,7),(3,5),(2,6),(11,5),(8,4),(9,7),(7,1),(1,3),(7,3),(5,3),(4,3),(1,2),(2,1),(2,7)";
                SqlCommand commandInsertIntoMinionsVillains = new SqlCommand(insertIntoMinionsVillainsQuery, connectionToMinionsDB);
                await commandInsertIntoMinionsVillains.ExecuteNonQueryAsync();
            }

        }
    }
}
