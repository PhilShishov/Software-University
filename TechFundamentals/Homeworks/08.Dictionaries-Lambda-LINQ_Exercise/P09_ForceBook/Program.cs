
namespace P09_ForceBook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> forcebook = new Dictionary<string, List<string>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Lumpawaroo")
                {
                    break;
                }

                if (command.Contains(" | "))
                {
                    string[] tokens = command.Split(new string[] { " | " }, StringSplitOptions.None);
                    string side = tokens[0];
                    string user = tokens[1];
                    if (forcebook.Values.Any(x => x.Contains(user)) == false)
                    {
                        if (forcebook.ContainsKey(side) == false)
                        {
                            forcebook.Add(side, new List<string>());
                        }
                        forcebook[side].Add(user);
                    }

                }
                else
                {
                    string[] tokens = command.Split(new string[] { " -> " }, StringSplitOptions.None);
                    string side = tokens[1];
                    string user = tokens[0];

                    if (forcebook.Any(x => x.Value.Contains(user)))
                    {
                        foreach (var pair in forcebook)
                        {
                            if (pair.Value.Contains(user))
                            {
                                forcebook[pair.Key].Remove(user);
                                break;
                            }
                        }
                    }
                    if (forcebook.ContainsKey(side))
                    {
                        forcebook[side].Add(user);
                    }
                    else
                    {
                        forcebook.Add(side, new List<string>() { user });
                    }
                    Console.WriteLine($"{user} joins the {side} side!");
                }

            }

            foreach (var pair in forcebook.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (pair.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {pair.Key}, Members: {pair.Value.Count}");
                }
                foreach (var user in pair.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}
