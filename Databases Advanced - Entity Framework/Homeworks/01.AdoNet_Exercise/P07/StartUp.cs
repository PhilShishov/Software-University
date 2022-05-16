
namespace P07
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            var names = new List<string>();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string minionsQuery = "SELECT Name FROM Minions";

                using (var command = new SqlCommand(minionsQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            names.Add((string)reader[0]);
                        }
                    }
                }
            }

            // testing
            //names = new List<string>();
            //names.Add("1");
            //names.Add("2");
            //names.Add("3");
            //names.Add("4");

            for (int i = 0; i < names.Count / 2; i++)
            {
                Console.WriteLine(names[i]);
                Console.WriteLine(names[names.Count - 1 - i]);
            }

            if (names.Count % 2 != 0)
            {
                Console.WriteLine(names[names.Count / 2]);
            }
        }
    }
}
