namespace _09._Increase_Age_Stored_Procedure
{
    using System;
    using System.Data.SqlClient;

    public class IncreaseAgeStoredProcedure
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int id = int.Parse(Console.ReadLine());

                string updateMinion =
                    "EXEC dbo.usp_GetOlder @id";
                using (SqlCommand command = new SqlCommand(updateMinion, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }

                string selectMinions = "SELECT Name, Age FROM Minions " +
                                       "WHERE Id = @id";
                using (SqlCommand command = new SqlCommand(selectMinions, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} - {reader[1]} years old");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
