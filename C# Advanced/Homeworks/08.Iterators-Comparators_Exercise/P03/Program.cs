using System;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();
            var command = Console.ReadLine();

            while (command != "END")
            {
                try
                {
                    if (command.Contains("Push"))
                    {
                        var items = command
                            .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .Select(int.Parse)
                            .ToList();

                        stack.Push(items);
                    }
                    else if (command == "Pop")
                    {                       
                        stack.Pop();
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                command = Console.ReadLine();
            }

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
