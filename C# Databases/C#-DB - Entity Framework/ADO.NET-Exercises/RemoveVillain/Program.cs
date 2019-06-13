using System;
using System.Data.SqlClient;

namespace RemoveVillain
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = @"SELECT Name FROM Villains WHERE Id = @villainId";
                string name = "";
                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    name = (string)command.ExecuteScalar();
                }

                if (name == null)
                {
                    Console.WriteLine("No such villain was found.");
                    return;
                }

                string deleteQuery = @"DELETE FROM MinionsVillains 
      WHERE VillainId = @villainId";
                int rowsAffected;

                using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    rowsAffected = command.ExecuteNonQuery();
                }

                string deleteVillain = @"DELETE FROM Villains
      WHERE Id = @villainId";

                using (SqlCommand command = new SqlCommand(deleteVillain, connection))
                {
                    command.Parameters.AddWithValue("@villainId", id);
                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"{name} was deleted.");
                Console.WriteLine($"{rowsAffected} minions were released.");
            }
        }
    }
}
