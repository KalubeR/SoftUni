using System;
using System.Data.SqlClient;

namespace VillainNames
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount FROM Villains AS v JOIN MinionsVillains AS mv ON v.Id = mv.VillainId GROUP BY v.Id, v.Name HAVING COUNT(mv.VillainId) > 3 ORDER BY COUNT(mv.VillainId)";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader["Name"];
                            int count = (int)reader["MinionsCount"];

                            Console.WriteLine($"{name} - {count}");
                        }
                    }
                }
            }
        }
    }
}
