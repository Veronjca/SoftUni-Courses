using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _06.RemoveVillain
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string getVillainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, connectionToMinionsDB);
                getVillainNameCommand.Parameters.AddWithValue("@villainId", villainId);
                SqlDataReader reader = await getVillainNameCommand.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                await reader.ReadAsync();
                string villainName = reader[0].ToString();
                await reader.CloseAsync();

                string getMinionsCountQuery = "SELECT COUNT(*) FROM MinionsVillains WHERE VillainId = @villainId";
                SqlCommand getMinionsCountCommand = new SqlCommand(getMinionsCountQuery, connectionToMinionsDB);
                getMinionsCountCommand.Parameters.AddWithValue("@villainId", villainId);
                int minionsCount = (int)await getMinionsCountCommand.ExecuteScalarAsync();

                string removeAllVillainToMinionRelationshipQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                SqlCommand removeAllVillainToMinionRelationshipCommand = new SqlCommand(removeAllVillainToMinionRelationshipQuery, connectionToMinionsDB);
                removeAllVillainToMinionRelationshipCommand.Parameters.AddWithValue("@villainId", villainId);
                await removeAllVillainToMinionRelationshipCommand.ExecuteNonQueryAsync();

                string removeVillainQuery = "DELETE FROM Villains WHERE Id = @villainId";
                SqlCommand removeVillainCommand = new SqlCommand(removeVillainQuery, connectionToMinionsDB);
                removeVillainCommand.Parameters.AddWithValue("@villainId", villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{minionsCount} minions were released.");
            }

        }
    }
}
