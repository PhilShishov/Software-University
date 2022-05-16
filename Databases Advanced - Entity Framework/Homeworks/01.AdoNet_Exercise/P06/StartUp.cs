﻿
namespace P06
{
    using System;
    using System.Data.SqlClient;

    using Data;
    public class StartUp
    {
        public static void Main()
        {
            int villainId = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string villainQuery = "SELECT Name FROM Villains WHERE Id = @villainId";
                string villainName;

                using (var command = new SqlCommand(villainQuery, connection))
                {
                    command.Parameters.AddWithValue("@villainId", villainId);
                    villainName = (string)command.ExecuteScalar();

                    if (villainName == null)
                    {
                        Console.WriteLine("No such villain was found.");
                        return;
                    }

                }

                int affectedRows = DeleteMinionsVillainById(connection, villainId);

                DeleteVillainsById(connection, villainId);

                Console.WriteLine($"{villainName} was deleted.");
                Console.WriteLine($"{affectedRows} minions were released.");
            }
        }

        private static void DeleteVillainsById(SqlConnection connection, int villainId)
        {
            string deleteVillainQuery = @"DELETE FROM Villains
                                                WHERE Id = @villainId";

            using (var command = new SqlCommand(deleteVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                command.ExecuteNonQuery();
            }
        }

        private static int DeleteMinionsVillainById(SqlConnection connection, int villainId)
        {
            string deleteMinionVillainQuery = @"DELETE FROM MinionsVillains
                                                WHERE VillainId = @villainId";

            using (var command = new SqlCommand(deleteMinionVillainQuery, connection))
            {
                command.Parameters.AddWithValue("@villainId", villainId);
                return command.ExecuteNonQuery();

            }
        }
    }
}
