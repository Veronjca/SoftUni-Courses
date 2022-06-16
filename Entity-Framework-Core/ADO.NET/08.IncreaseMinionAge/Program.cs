using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _08.IncreaseMinionAge
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string updateMinionsAgeAndNameQuery = " UPDATE Minions SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1 WHERE Id = @Id";
                SqlCommand updateMinionsNameAndAgeCommand = new SqlCommand(updateMinionsAgeAndNameQuery, connectionToMinionsDB);

                foreach (var id in ids)
                {
                    updateMinionsNameAndAgeCommand.Parameters.Clear();
                    updateMinionsNameAndAgeCommand.Parameters.AddWithValue("@Id", id);
                    await updateMinionsNameAndAgeCommand.ExecuteNonQueryAsync();
                }

                string getAllMinionsQuery = "SELECT Name, Age FROM Minions";
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(getAllMinionsQuery, connectionToMinionsDB);

                using (adapter)
                {
                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row[0]} {row[1]}");
                }
            }
        }
    }
}
