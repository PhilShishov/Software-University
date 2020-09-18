using System;
using System.Linq;

namespace P02_SantasList
{
    class SantasList
    {
        static void Main(string[] args)
        {
            var kids = Console.ReadLine().Split("&").ToList();

            string input = Console.ReadLine();

            while (input != "Finished!")
            {
                var commands = input.Split();
                string command = commands[0];
                string name = commands[1];

                switch (command)
                {
                    case "Bad":
                        if (!kids.Contains(name))
                        {
                            kids.Insert(0, name);
                        }
                        break;

                    case "Good":
                        if (kids.Contains(name))
                        {
                            kids.Remove(name);
                        }
                        break;

                    case "Rename":
                        string newName = commands[2];
                        if (kids.Contains(name))
                        {
                            int index = kids.IndexOf(name);
                            kids.Insert(index, newName);
                            kids.Remove(name);
                        }
                        break;

                    case "Rearrange":
                        if (kids.Contains(name))
                        {
                            kids.Remove(name);
                            kids.Add(name);
                        }
                        break;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", kids));
        }
    }
}
