
namespace P02_VillainNames
{
    using System;
    using System.Data.SqlClient;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string sqlQuery = @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
                                    FROM Villains AS v 
                                    JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
                                GROUP BY v.Id, v.Name 
                                  HAVING COUNT(mv.VillainId) > 3 
                                ORDER BY COUNT(mv.VillainId)";

                using (var command = new SqlCommand(sqlQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = (string)reader["Name"]; //reader[0];
                            int count = (int)reader[1];

                            Console.WriteLine($"{name} - {count}");

                        }
                    }
                }
            }
        }
    }
}
