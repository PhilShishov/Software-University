
namespace P09
{
    using System;
    using System.Data.SqlClient;

    using Data;
 
    public class StartUp
    {
        public static void Main()
        {
            int id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string uspGetOlderProc = "EXEC usp_GetOlder @id";

                using (var command = new SqlCommand(uspGetOlderProc, connection))
                {
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        string name = (string)reader[0];
                        int age = (int)reader[1];

                        Console.WriteLine($"{name} - {age} years old");
                    }
                }
            }
        }
    }
}
