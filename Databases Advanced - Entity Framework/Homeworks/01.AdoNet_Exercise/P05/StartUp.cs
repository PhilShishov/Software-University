﻿
namespace P05
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    using Data;

    public class StartUp
    {
        public static void Main()
        {
            string countryName = Console.ReadLine();

            using (var connection = new SqlConnection(Configuration.ConnectionString))
            {
                connection.Open();

                string updateTownNames = @"UPDATE Towns
                                              SET Name = UPPER(Name)
                                            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

                using (var command = new SqlCommand(updateTownNames, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    int rowsAffected = command.ExecuteNonQuery();

                    Console.WriteLine($"{rowsAffected} town names were affected.");
                }

                string townNamesQuery = @"SELECT t.Name 
                                            FROM Towns as t
                                            JOIN Countries AS c ON c.Id = t.CountryCode
                                           WHERE c.Name = @countryName";

                List<string> towns = new List<string>();

                using (var command = new SqlCommand(townNamesQuery, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            towns.Add((string)reader[0]);
                        }
                    }
                }
                Console.WriteLine("[" + string.Join(", ", towns) + "]");
            }

        }
    }
}
