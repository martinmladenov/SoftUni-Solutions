namespace _04._Add_Minion
{
    using System;
    using System.Data.SqlClient;

    public class AddMinion
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var minionData = Console.ReadLine().Split();
                var villainData = Console.ReadLine().Split();

                string name = minionData[1];
                int age = int.Parse(minionData[2]);
                string town = minionData[3];
                string villain = villainData[1];

                // get town id
                int? townId = GetTownId(town, connection);
                if (townId == null)
                {
                    string insertTown = "INSERT INTO Towns (Name) VALUES (@name)";
                    using (SqlCommand command = new SqlCommand(insertTown, connection))
                    {
                        command.Parameters.AddWithValue("@name", town);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Town {town} was added to the database.");
                }

                townId = GetTownId(town, connection);
                
                // get villain id
                int? villainId = GetVillainId(villain, connection);
                if (villainId == null)
                {
                    string insertVillain = "INSERT INTO Villains (Name) VALUES (@name)";
                    using (SqlCommand command = new SqlCommand(insertVillain, connection))
                    {
                        command.Parameters.AddWithValue("@name", villain);

                        command.ExecuteNonQuery();
                    }

                    Console.WriteLine($"Villain {villain} was added to the database.");
                }

                villainId = GetVillainId(villain, connection);

                // insert minion
                string insertMinion =
                    "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
                using (SqlCommand command = new SqlCommand(insertMinion, connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@townId", townId);

                    command.ExecuteNonQuery();
                }

                int minionId;
                string selectMinionId =
                    "SELECT Id FROM Minions WHERE Name = @name";
                using (SqlCommand command = new SqlCommand(selectMinionId, connection))
                {
                    command.Parameters.AddWithValue("@name", name);

                    minionId = (int)command.ExecuteScalar();
                }

                // insert into MinionsVillains
                string insertMinionVillain = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
                using (SqlCommand command = new SqlCommand(insertMinionVillain, connection))
                {
                    command.Parameters.AddWithValue("@minionId", minionId);
                    command.Parameters.AddWithValue("@villainId", villainId);

                    command.ExecuteNonQuery();
                }

                Console.WriteLine($"Successfully added {name} to be minion of {villain}.");

                connection.Close();
            }
        }

        private static int? GetTownId(string name, SqlConnection connection)
        {
            string selectTownId =
                "SELECT Id FROM Towns WHERE Name = @name";
            using (SqlCommand command = new SqlCommand(selectTownId, connection))
            {
                command.Parameters.AddWithValue("@name", name);

                return (int?)command.ExecuteScalar();
            }
        }

        private static int? GetVillainId(string name, SqlConnection connection)
        {
            string selectVillainId =
                "SELECT Id FROM Villains WHERE Name = @name";
            using (SqlCommand command = new SqlCommand(selectVillainId, connection))
            {
                command.Parameters.AddWithValue("@name", name);

                return (int?)command.ExecuteScalar();
            }
        }
    }
}
