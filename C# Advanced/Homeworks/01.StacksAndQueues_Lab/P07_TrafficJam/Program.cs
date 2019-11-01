using System;
using System.Collections.Generic;

namespace P07_TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();
            int count = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int number = 0;

            while (command?.ToLower() != "end")
            {
                if (command?.ToLower() == "green")
                {
                    int currentCount = queue.Count > count ? count : queue.Count;

                    for (int i = 0; i < currentCount; i++)
                    {
                        Console.WriteLine($"{queue.Dequeue()} passed!");
                        number++;
                    }
                }
                else
                {
                    queue.Enqueue(command);

                }
                command = Console.ReadLine();
            }

            Console.WriteLine($"{number} cars passed the crossroads.");
        }
    }
}
