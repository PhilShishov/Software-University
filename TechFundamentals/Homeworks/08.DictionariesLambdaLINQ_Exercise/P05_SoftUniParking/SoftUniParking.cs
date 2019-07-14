
namespace P05_SoftUniParking
{
    using System;
    using System.Collections.Generic;

    class SoftUniParking
    {
        static void Main()
        {
            var registeredUsers = new Dictionary<string, string>();

            int commandCount = int.Parse(Console.ReadLine());

            while (commandCount > 0)
            {
                string[] tokens = Console.ReadLine().Split();

                switch (tokens[0])
                {
                    case "register":
                        string nameToRegister = tokens[1];
                        string licence = tokens[2];

                        if (registeredUsers.ContainsKey(nameToRegister))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licence}");
                        }
                        else
                        {
                            registeredUsers.Add(nameToRegister, licence);
                            Console.WriteLine($"{nameToRegister} registered {licence} successfully");
                        }
                        break;

                    case "unregister":
                        string nameToUnregister = tokens[1];

                        if (!registeredUsers.ContainsKey(nameToUnregister))
                        {
                            Console.WriteLine($"ERROR: user {nameToUnregister} not found");
                        }
                        else
                        {
                            registeredUsers.Remove(nameToUnregister);
                            Console.WriteLine($"{nameToUnregister} unregistered successfully");
                        }
                        break;
                    default:
                        break;
                }

                commandCount--;
            }

            foreach (var kvp in registeredUsers)
            {
                string username = kvp.Key;
                string licence = kvp.Value;
                Console.WriteLine($"{username} => {licence}");
            }
        }
    }
}
