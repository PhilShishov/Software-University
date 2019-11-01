
namespace P02_StackSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StackSum
    {
        public static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(input);


            while (true)
            {
                string commandInfo = Console.ReadLine().ToLower();

                if (commandInfo == "end")
                {
                    break;
                }

                string[] tokens = commandInfo.Split();
                string command = tokens[0].ToLower();

                if (command == "add")
                {
                    int firstNum = int.Parse(tokens[1]);
                    stack.Push(firstNum);
                    int secondNum = int.Parse(tokens[2]);
                    stack.Push(secondNum);
                }
                else if (command == "remove")
                {
                    var countOfRemovedNums = int.Parse(tokens[1]);

                    if (stack.Count < countOfRemovedNums)
                        continue;

                    for (int i = 0; i < countOfRemovedNums; i++)
                    {
                        stack.Pop();
                    }
                }
            }

            var sum = stack.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
