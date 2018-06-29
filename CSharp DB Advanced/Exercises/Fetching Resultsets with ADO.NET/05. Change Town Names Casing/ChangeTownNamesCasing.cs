using System;

namespace _05._Change_Town_Names_Casing
{
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class ChangeTownNamesCasing
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                string countryName = Console.ReadLine();

                string updateCommand =
                    "UPDATE t " +
                    "SET t.Name = UPPER(t.Name) " +
                    "FROM Towns t JOIN Countries c ON t.CountryCode = c.Id " +
                    "WHERE c.Name = @name";
                using (SqlCommand command = new SqlCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@name", countryName);
                    command.ExecuteNonQuery();
                }

                List<string> towns = new List<string>();

                string selectCommand = 
                    "SELECT t.Name " +
                    "FROM Towns t JOIN Countries c ON t.CountryCode = c.Id " +
                    "WHERE c.Name = @name";
                using (SqlCommand command = new SqlCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@name", countryName);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }

                if (towns.Count != 0)
                {
                    Console.WriteLine($"{towns.Count} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", towns)}]");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                }

                connection.Close();
            }
        }
    }
}
