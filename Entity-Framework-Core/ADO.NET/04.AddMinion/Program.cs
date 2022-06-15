using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _04.AddMinion
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split(' ');
            string[] villianInfo = Console.ReadLine().Split(' ');
            string minionName = minionInfo[1];
            int minionAge = int.Parse(minionInfo[2]);
            string townName = minionInfo[3];
            string villainName = villianInfo[1];

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string getVillainQuery = "SELECT Id FROM Villains WHERE Name = @Name";
                SqlCommand getVillainCommand = new SqlCommand(getVillainQuery, connectionToMinionsDB);
                getVillainCommand.Parameters.AddWithValue("@Name", villainName);
                SqlDataReader villainReader = await getVillainCommand.ExecuteReaderAsync();

                string getTownQuery = "SELECT Id FROM Towns WHERE Name = @townName";
                SqlCommand getTownCommand = new SqlCommand(getTownQuery, connectionToMinionsDB);
                getTownCommand.Parameters.AddWithValue("@townName", townName);
                SqlDataReader townReader = await getTownCommand.ExecuteReaderAsync();


                if (!townReader.HasRows)
                {
                    string addTownQuery = "INSERT INTO Towns (Name) VALUES (@townName)";
                    SqlCommand addTownCommand = new SqlCommand(addTownQuery, connectionToMinionsDB);
                    addTownCommand.Parameters.AddWithValue("@townName", townName);
                    await addTownCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Town {townName} was added to the database.");
                }

                await townReader.CloseAsync();

                if (!villainReader.HasRows)
                {
                    string addVillainQuery = "INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";
                    SqlCommand addVillainCommand = new SqlCommand(addVillainQuery, connectionToMinionsDB);
                    addVillainCommand.Parameters.AddWithValue("@villainName", villainName);
                    await addVillainCommand.ExecuteNonQueryAsync();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                await villainReader.CloseAsync();

                int townId = (int)await getTownCommand.ExecuteScalarAsync();

                string addMinionQuery = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                SqlCommand addMinionCommand = new SqlCommand(addMinionQuery, connectionToMinionsDB);
                addMinionCommand.Parameters.AddWithValue("@name", minionName);
                addMinionCommand.Parameters.AddWithValue("@age", minionAge);
                addMinionCommand.Parameters.AddWithValue("@townId", townId);
                await addMinionCommand.ExecuteNonQueryAsync();

                int villainId = (int)await getVillainCommand.ExecuteScalarAsync();               

                string addMinionToVillainQuery = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                SqlCommand addMinionToVillainCommand = new SqlCommand(addMinionToVillainQuery, connectionToMinionsDB);
                addMinionToVillainCommand.Parameters.AddWithValue("@villainId", villainId);

                string getMinionQuery = "SELECT Id FROM Minions WHERE Name = @Name";
                SqlCommand getMinionIdCommand = new SqlCommand(getMinionQuery, connectionToMinionsDB);
                getMinionIdCommand.Parameters.AddWithValue("@Name", minionName);
                int minionId = (int)await getMinionIdCommand.ExecuteScalarAsync();

                addMinionToVillainCommand.Parameters.AddWithValue("@minionId", minionId);
                await addMinionToVillainCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");

            }

        }
    }
}
