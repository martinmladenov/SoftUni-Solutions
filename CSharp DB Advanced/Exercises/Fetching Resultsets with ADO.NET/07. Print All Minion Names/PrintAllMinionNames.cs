namespace _07._Print_All_Minion_Names
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class PrintAllMinionNames
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                List<string> names = new List<string>();

                string selectNames = "SELECT Name FROM Minions";
                using (SqlCommand command = new SqlCommand(selectNames, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add((string)reader[0]);
                        }
                    }
                }

                for (int i = 0; i < names.Count; i++)
                {
                    Console.WriteLine(names[i % 2 == 0 ? i / 2 : names.Count - 1 - i / 2]);
                }

                connection.Close();
            }
        }
    }
}
