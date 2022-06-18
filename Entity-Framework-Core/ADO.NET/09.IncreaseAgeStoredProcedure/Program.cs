using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace _09.IncreaseAgeStoredProcedure
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int minionId = int.Parse(Console.ReadLine());

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            using (connectionToMinionsDB)
            {
                string procedure = "usp_GetOlder";
                SqlCommand getOlderCommand = new SqlCommand(procedure, connectionToMinionsDB);
                getOlderCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter param = getOlderCommand.Parameters.Add("@id", SqlDbType.Int);
                param.Value = minionId;

                await getOlderCommand.ExecuteNonQueryAsync();

                string getMinionInfoQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(getMinionInfoQuery, connectionToMinionsDB);
                adapter.SelectCommand.Parameters.AddWithValue("@Id", minionId);

                using(adapter)
                {
                    adapter.Fill(table);
                }

                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"{row[0]} – {row[1]} years old");
                }
            }
        }
    }
}
