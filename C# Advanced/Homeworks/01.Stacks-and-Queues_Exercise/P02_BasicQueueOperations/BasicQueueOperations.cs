
namespace P02_BasicQueueOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BasicQueueOperations
    {
        static void Main()
        {
            var inputCommand = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var enqueueCommand = int.Parse(inputCommand[0]);
            var dequeueCommand = int.Parse(inputCommand[1]);
            var checkCommand = int.Parse(inputCommand[2]);

            var inputNumbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < enqueueCommand; i++)
            {
                queue.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < dequeueCommand; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(checkCommand))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (queue.Count == 0)
                {
                    Console.WriteLine(0);
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }
        }
    }
}
