using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _03.MinionNames
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int villainID = int.Parse(Console.ReadLine());

            string connectionStringToMinionsDB = "Server=localhost;Database=MinionsDB;User=sa;Password=A3047744;Trusted_Connection= False;MultipleActiveResultSets=true;Encrypt=False";

            
            SqlConnection connectionToMinionsDB = new SqlConnection(connectionStringToMinionsDB);
            await connectionToMinionsDB.OpenAsync();

            await using(connectionToMinionsDB)
            {
                string getVillainNameQuery = "SELECT Name FROM Villains WHERE Id = @villainID";
                string getMinionsInfoQuery = $"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum, m.Name,  m.Age FROM MinionsVillains AS mv JOIN Minions As m ON mv.MinionId = m.Id WHERE mv.VillainId = {villainID} ORDER BY m.Name";

                SqlCommand getVillainNameCommand = new SqlCommand(getVillainNameQuery, connectionToMinionsDB);
                getVillainNameCommand.Parameters.AddWithValue("@villainID", villainID);
                string villainName = (string) await getVillainNameCommand.ExecuteScalarAsync();

                if (string.IsNullOrEmpty(villainName))
                {
                    Console.WriteLine($"No villain with ID {villainID} exists in the database.");
                    return;
                }
                else
                {
                    DataTable table = new DataTable();
                    SqlDataAdapter adapter = new SqlDataAdapter(getMinionsInfoQuery, connectionToMinionsDB);
                    using (adapter)
                    {
                        adapter.Fill(table);
                    }

                    Console.WriteLine($"Villain: {villainName}");
                    if(table.Rows.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            Console.WriteLine($"{row[0]}. {row[1]} {row[2]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("(no minions)");
                    }                                                    
                }
            }
        }
    }
}
