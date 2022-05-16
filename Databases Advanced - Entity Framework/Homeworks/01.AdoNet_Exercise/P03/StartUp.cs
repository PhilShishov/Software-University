
namespace P03
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

                string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @id";

                using (var command = new SqlCommand(villainNameQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    string villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }

                    Console.WriteLine($"Villain: {villainName}");
                }

                string minionsQUery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

                using (var command = new SqlCommand(minionsQUery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            long rowNumber = (long)reader[0];
                            string name = (string)reader[1];
                            int age = (int)reader[2];


                            Console.WriteLine($"{rowNumber}. {name} {age}");
                        }

                        if (!reader.HasRows)
                        {
                            Console.WriteLine("no minions");
                        }
                    }
                }

            }
        }
    }
}
