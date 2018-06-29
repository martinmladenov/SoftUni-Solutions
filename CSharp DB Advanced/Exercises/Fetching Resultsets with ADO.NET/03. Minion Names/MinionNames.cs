namespace _03._Minion_Names
{
    using System;
    using System.Data.SqlClient;

    public class MinionNames
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int id = int.Parse(Console.ReadLine());

                bool exists;

                string selectVillainName =
                    "SELECT Name FROM Villains WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(selectVillainName, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    string villainName = (string)command.ExecuteScalar();
                    {
                        exists = villainName != null;

                        if (exists)
                            Console.WriteLine($"Villain: {villainName}");
                        else
                            Console.WriteLine($"No villain with ID {id} exists in the database.");
                    }
                }

                if (exists)
                {
                    string selectCommand =
                        "SELECT m.Name, m.Age FROM MinionsVillains mv " +
                        "JOIN Minions m ON m.Id = mv.MinionId " +
                        "WHERE mv.VillainId = @id " +
                        "ORDER BY m.Name ASC";
                    using (SqlCommand command = new SqlCommand(selectCommand, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                for (int i = 1; reader.Read(); i++)
                                {
                                    Console.WriteLine($"{i}. {reader[0]} {reader[1]}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("(no minions)");
                            }

                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
