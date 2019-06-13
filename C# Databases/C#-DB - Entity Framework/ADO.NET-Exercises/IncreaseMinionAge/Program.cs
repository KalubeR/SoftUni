using System;
using System.Data.SqlClient;
using System.Linq;

namespace IncreaseMinionAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateQuery = @"UPDATE Minions
   SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
 WHERE Id = @Id";

                foreach (var id in ids)
                {
                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }

                string selectQuery = @"SELECT Name, Age FROM Minions";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];

                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }
            }
        }
    }
}
