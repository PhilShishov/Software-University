using System;
using System.Collections.Generic;
using System.Linq;

namespace P07
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new Dictionary<string, HashSet<string>>();
            var followers = new Dictionary<string, HashSet<string>>();

            string command = "";

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];
                string commandType = tokens[1];

                if (commandType == "joined")
                {
                    if (users.ContainsKey(username) == false)
                    {
                        users.Add(username, new HashSet<string>());
                        followers.Add(username, new HashSet<string>());
                    }
                }
                else if (commandType == "followed")
                {
                    string followedUsername = tokens[2];

                    if (users.ContainsKey(username) && username != followedUsername)
                    {
                        users[username].Add(followedUsername);
                        followers[followedUsername].Add(username);
                    }
                }
            }

            Console.WriteLine($"The V-Logger has a total of {users.Count} vloggers in its logs.");
            int rank = 1;

            foreach (var user in users.OrderByDescending(x => followers[x.Key].Count).ThenBy(x => x.Value.Count))
            {
                if (rank == 1)
                {
                    Console.WriteLine($"{rank++}. {user.Key} : {followers[user.Key].Count} followers, {user.Value.Count} following");
                    foreach (var follower in followers[user.Key].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                else
                {
                    Console.WriteLine($"{rank++}. {user.Key} : {followers[user.Key].Count} followers, {user.Value.Count} following");
                }
            }
        }
    }
}
