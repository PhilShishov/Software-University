
namespace P02_CommonElements
{
    using System;
    using System.Linq;

    class CommonElements
    {
        static void Main()
        {
            string[] firstArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] secondArray = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            for (int i = 0; i < secondArray.Length; i++)
            {
                if (firstArray.Contains(secondArray[i]))
                {
                    Console.Write(secondArray[i] + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
