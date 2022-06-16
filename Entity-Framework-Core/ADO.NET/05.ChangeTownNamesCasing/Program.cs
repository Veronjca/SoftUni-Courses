using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _05.ChangeTownNamesCasing
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string countryName = Console.ReadLine();

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using (connectionToMinionsDB)
            {
                string selectTownsQuery = "SELECT t.Name FROM Towns as t JOIN Countries AS c ON c.Id = t.CountryCode WHERE c.Name = @countryName";
                SqlCommand selectTownsCommand = new SqlCommand(selectTownsQuery, connectionToMinionsDB);
                selectTownsCommand.Parameters.AddWithValue("@countryName", countryName);
                SqlDataReader reader = await selectTownsCommand.ExecuteReaderAsync();

                if (!reader.HasRows)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                string changeTownsCasingQuery = "UPDATE Towns SET Name = UPPER(Name) WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
                SqlCommand changeTownsCasingCommand = new SqlCommand(changeTownsCasingQuery, connectionToMinionsDB);
                changeTownsCasingCommand.Parameters.AddWithValue("@countryName", countryName);
                await changeTownsCasingCommand.ExecuteNonQueryAsync();

                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(selectTownsQuery, connectionToMinionsDB);
                adapter.SelectCommand.Parameters.AddWithValue("@countryName", countryName);
                using (adapter)
                {
                    adapter.Fill(table);
                }

                int affectedTownsCount = table.Rows.Count;

                await reader.CloseAsync();
                Console.WriteLine($"{affectedTownsCount} town names were affected.");

                List<string> towns = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    towns.Add(row[0].ToString());
                }

                Console.WriteLine($"[{String.Join(", ", towns)}]");
            }
        }
    }
}
