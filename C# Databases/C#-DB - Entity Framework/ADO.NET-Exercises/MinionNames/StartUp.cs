using System;
using System.Data.SqlClient;

namespace MinionNames
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string commandString = "SELECT Name FROM Villains WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(commandString, connection))
                {
                    command.Parameters.AddWithValue("@Id", n);
                    string name = (string)command.ExecuteScalar();

                    if (name == null)
                    {
                        Console.WriteLine($"No villain with ID {n} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {name}");
                }

                string minionsQuery = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (SqlCommand command = new SqlCommand(minionsQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", n);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long row = (long)reader[0];
                            string name = (string)reader[1];
                            int id = (int)reader[2];

                            Console.WriteLine($"{row}. {name} {id}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                    }
                }
            }
        }
    }
}
