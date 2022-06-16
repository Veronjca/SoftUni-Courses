using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace _07.PrintAllMinionNames
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
                string selectMinionsNamesQuery = "SELECT Name FROM Minions";
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(selectMinionsNamesQuery, connectionToMinionsDB);

                using (adapter)
                {
                    adapter.Fill(table);
                }

                int counter = 0;

                while (counter <= ((table.Rows.Count - 1) / 2))
                {
                    DataRow nextFromFirst = table.Rows[0 + counter];
                    DataRow beforeFromLast = table.Rows[table.Rows.Count - 1 - counter];
                    Console.WriteLine(nextFromFirst[0]);
                    if(table.Rows.Count % 2 != 0 && counter == (table.Rows.Count - 1) / 2)
                    {
                        counter++;
                        continue;
                    }
                    Console.WriteLine(beforeFromLast[0]);
                    counter++;
                }
            }
        }
    }
}
