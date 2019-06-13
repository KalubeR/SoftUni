using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ChangeTownNamesCasing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string country = Console.ReadLine();

            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertSql = @"UPDATE Towns
   SET Name = UPPER(Name)
 WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (SqlCommand command = new SqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    int rows = command.ExecuteNonQuery();

                    if (rows == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        return;
                    }
                    Console.WriteLine($"{rows} town names were affected. ");
                }

                string selectQuery = @" SELECT t.Name 
   FROM Towns as t
   JOIN Countries AS c ON c.Id = t.CountryCode
  WHERE c.Name = @countryName";
                List<string> towns = new List<string>();

                using (SqlCommand command = new SqlCommand(selectQuery,connection))
                {
                    command.Parameters.AddWithValue("@countryName", country);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }
    }
}
