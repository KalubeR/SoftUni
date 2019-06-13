using System;
using System.Data.SqlClient;

namespace IncreaseAgeStoredProcedure
{
    class Program
    {
        static void Main(string[] args)
        {
            string id = Console.ReadLine();

            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string execProc = @"EXEC dbo.usp_GetOlder @id";

                using (SqlCommand command = new SqlCommand(execProc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }

                string selectQuery = @"SELECT Name, Age FROM Minions WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Console.WriteLine($"{reader[0]} – {reader[1]} years old");
                    }
                }
            }
        }
    }
}
