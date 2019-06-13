using System;
using System.Data.SqlClient;

namespace AddMinion
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string town = minionInfo[3];

            string villainName = villainInfo[1];

            string connectionString = @"Server=DESKTOP-M55K9NF\SQLEXPRESS;Database=MinionsDB;"
                                    + "Integrated Security=true;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                int? townId = CheckTown(connection, town);

                string insertTownQuery = @"INSERT INTO Towns (Name) VALUES (@townName)";

                if (townId == null)
                {
                    AddTown(connection, town, insertTownQuery);
                }

                InsertMinion(minionName, age, town, connection, townId);

                int? villainId = CheckVillain(connection, villainName);

                string insertVillainQuery = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

                if (villainId == null)
                {
                    AddVillain(connection, villainName, insertVillainQuery);
                }

                int minionId = GetMinionId(connection, minionName);

                SetMinion(villainId, minionId, connection, villainName, minionName);
            }
        }

        private static void SetMinion(int? villainId, int minionId, SqlConnection connection, string villainName, string minionName)
        {
            string insertQuery = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@villainId, @minionId)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.Parameters.AddWithValue("@minionId", minionId);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static int GetMinionId(SqlConnection connection, string minionName)
        {
            string commandQuery = @"SELECT Id FROM Minions WHERE Name = @Name";

            using (SqlCommand command = new SqlCommand(commandQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", minionName);
                int minionId = (int)command.ExecuteScalar();
                return minionId;
            }
        }

        private static int? CheckVillain(SqlConnection connection, string villainName)
        {
            string villainQuery = @"SELECT Id FROM Villains WHERE Name = @Name";
            int? villainId;

            using (SqlCommand command = new SqlCommand(villainQuery, connection))
            {
                command.Parameters.AddWithValue("@Name", villainName);
                villainId = (int?)command.ExecuteScalar();
                return villainId;
            }
        }

        private static void AddVillain(SqlConnection connection, string villainName, string insertVillainQuery)
        {
            using (SqlCommand command = new SqlCommand(insertVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainName", villainName);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Villain {villainName} was added to the database.");
        }

        private static void InsertMinion(string minionName, int age, string town, SqlConnection connection, int? townId)
        {
            string insertQuery = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@name", minionName);
                command.Parameters.AddWithValue("@age", age);
                command.Parameters.AddWithValue("@townId", townId);
                command.ExecuteNonQuery();
            }
        }


        private static int? CheckTown(SqlConnection connection, string town)
        {
            string townQuery = @"SELECT Id FROM Towns WHERE Name = @townName";
            int? townId;
            using (SqlCommand command = new SqlCommand(townQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", town);
                townId = (int?)command.ExecuteScalar();
                return townId;
            }

        }

        private static void AddTown(SqlConnection connection, string town, string insertTownQuery)
        {
            using (SqlCommand command = new SqlCommand(insertTownQuery, connection))
            {
                command.Parameters.AddWithValue("@townName", town);
                command.ExecuteNonQuery();
            }
            Console.WriteLine($"Town {town} was added to the database.");
        }
    }
}
