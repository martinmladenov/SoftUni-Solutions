namespace _08._Increase_Minion_Age
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class IncreaseMinionAge
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=MinionsDb;Integrated Security=True";

        public static void Main()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

                string createTitleCaseFunction = 
                    "CREATE OR ALTER FUNCTION dbo.fn_capitalize "+
                    "( "+
                    "@str AS nvarchar(100) "+
                    ") "+
                    "RETURNS nvarchar(100) "+
                    "AS "+
                    "BEGIN "+
                    "DECLARE "+
                    "@ret_str AS varchar(100), "+
                    "@pos AS int, "+
                    "@len AS int "+
                    "SELECT "+
                    "@ret_str = N' ' + LOWER(@str), "+
                    "@pos = 1, "+
                    "@len = LEN(@str) + 1 "+
                    "WHILE @pos > 0 AND @pos<@len "+
                    "BEGIN "+
                    "SET @ret_str = STUFF(@ret_str, "+
                    "@pos + 1, "+
                    "1, "+
                    "UPPER(SUBSTRING(@ret_str, @pos + 1, 1))) "+
                    "SET @pos = CHARINDEX(N' ', @ret_str, @pos + 1) "+
                    "END "+
                    "RETURN RIGHT(@ret_str, @len -1) "+
                    "END";
                using (SqlCommand command = new SqlCommand(createTitleCaseFunction, connection))
                {
                    command.ExecuteNonQuery();
                }

                foreach (var id in ids)
                {
                    string updateMinions =
                        "UPDATE Minions " +
                        "SET Name = dbo.fn_capitalize(Name), Age += 1 " +
                        "WHERE Id = @id";
                    using (SqlCommand command = new SqlCommand(updateMinions, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        command.ExecuteNonQuery();
                    }
                }

                string selectMinions = "SELECT Name, Age FROM Minions";
                using (SqlCommand command = new SqlCommand(selectMinions, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }

                connection.Close();
            }
        }
    }
}
