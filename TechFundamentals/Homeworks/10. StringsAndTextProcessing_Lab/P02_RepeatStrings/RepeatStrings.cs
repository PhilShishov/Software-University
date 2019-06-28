
namespace P02_RepeatStrings
{
    using System;
    using System.Text;

    class RepeatStrings
    {
        static void Main()
        {
            string[] words = Console.ReadLine()
                .Split();

            StringBuilder result = new StringBuilder();

            foreach (string word in words)
            {
                int count = word.Length;

                for (int i = 0; i < count; i++)
                {
                    result.Append(word); 
                }
            }

            Console.WriteLine(result);

        }
    }
}
