
namespace P01
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());

            Stack<string> input = new Stack<string>(Console.ReadLine().Split());
            Queue<string> halls = new Queue<string>();
            List<int> reservations = new List<int>();

            int currentCapacity = 0;

            while (input.Count > 0)
            {
                var currentHall = input.Pop();
                bool isNum = int.TryParse(currentHall, out int parsedNum);

                if (!isNum)
                {
                    halls.Enqueue(currentHall);
                }
                else
                {
                    if (parsedNum + currentCapacity > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", reservations)}");
                        reservations.Clear();
                        currentCapacity = 0;
                    }

                    if (halls.Count > 0)
                    {
                        reservations.Add(parsedNum);
                        currentCapacity += parsedNum;
                    }
                }
            }
        }
    }
}
