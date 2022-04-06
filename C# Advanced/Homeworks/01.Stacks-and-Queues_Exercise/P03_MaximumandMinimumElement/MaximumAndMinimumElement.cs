
namespace P03_MaximumandMinimumElement
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class MaximumAndMinimumElement
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();

            Stack<int> integers = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                int currentOperation = tokens[0];

                if (currentOperation == 1)
                {
                    integers.Push(tokens[1]);
                }

                else if (currentOperation == 2 && integers.Count > 0)
                {
                    integers.Pop();
                }

                else if (currentOperation == 3 && integers.Count > 0)
                {
                    result.Append($"{integers.Max()}{Environment.NewLine}");
                }

                else if (currentOperation == 4 && integers.Count > 0)
                {
                    result.Append($"{integers.Min()}{Environment.NewLine}");
                }
            }

            result.AppendJoin(", ", integers);
            Console.WriteLine(result);
        }
    }
}
