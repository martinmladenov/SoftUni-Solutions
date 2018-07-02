namespace _06._Remove_Villain
{
    using System;
    using System.Data.SqlClient;

    public class RemoveVillain
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int id = int.Parse(Console.ReadLine());

                string name;

                string selectName =
                    "SELECT Name " +
                    "FROM Villains " +
                    "WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(selectName, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    name = (string)command.ExecuteScalar();
                }

                if (name != null)
                {
                    Console.WriteLine($"{name} was deleted.");

                    string deleteMinionsVillains =
                        "DELETE FROM MinionsVillains " +
                        "WHERE VillainId = @id";
                    using (SqlCommand command = new SqlCommand(deleteMinionsVillains, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        int count = command.ExecuteNonQuery();
                        Console.WriteLine($"{count} minions were released.");
                    }

                    string deleteVillain =
                        "DELETE FROM Villains " +
                        "WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(deleteVillain, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    Console.WriteLine("No such villain was found.");
                }

                connection.Close();
            }
        }
    }
}
