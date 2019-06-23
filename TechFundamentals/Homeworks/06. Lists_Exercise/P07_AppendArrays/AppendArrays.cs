
namespace P07_AppendArrays
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class AppendArrays
    {
        static void Main()
        {
            var input = Console.ReadLine().Split('|').ToArray();
            var result = new List<string>();
            Array.Reverse(input);
            foreach (var token in input)
            {
                string[] numbers = token.Split(' ');
                foreach (var item in numbers)
                {

                    if (item != "")
                    {
                        result.Add(item);
                    }
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
