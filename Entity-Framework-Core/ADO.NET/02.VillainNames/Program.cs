using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _02.VillainNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string getVillainsNamesQuery = "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";

                SqlCommand commandToGetVillainsNames = new SqlCommand(getVillainsNamesQuery, connectionToMinionsDB);
                SqlDataReader reader = await commandToGetVillainsNames.ExecuteReaderAsync();
                
                await using (reader)
                {
                      while(await reader.ReadAsync())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {         
                            Console.Write($"{reader[i]} - {reader[i+1]} ");
                            break;
                        }
                    }
                }
            }
        }
    }
}
