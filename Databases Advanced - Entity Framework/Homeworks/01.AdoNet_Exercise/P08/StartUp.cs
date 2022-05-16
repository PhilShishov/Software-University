﻿
namespace P08
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    using Data;
 
    public class StartUp
    {
        public static void Main()
        {
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateMinions = @"UPDATE Minions
                                                 SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                                               WHERE Id = @Id";
                for (int i = 0; i < ids.Length; i++)
                {
                    using (var command = new SqlCommand(updateMinions, connection))
                    {
                        command.Parameters.AddWithValue("@Id", ids[1]);
                        command.ExecuteNonQuery();                        
                    }
                }

                string minionsQuery = "SELECT Name, Age FROM Minions";

                using (var command = new SqlCommand(minionsQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader[0];
                            int age = (int)reader[1];
                            Console.WriteLine($"{name} {age}");
                        }
                    }
                }

            }
        }
    }
}
