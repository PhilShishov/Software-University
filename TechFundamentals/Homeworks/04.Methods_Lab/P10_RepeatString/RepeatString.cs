
namespace P10_RepeatString
{
    using System;

    class RepeatString
    {
        static void Main()
        {
            string text = Console.ReadLine();
            int count = int.Parse(Console.ReadLine());

            RepeatStringMethod(text, count);
        }

        private static string RepeatStringMethod(string text, int count)
        {
            string result = string.Empty;

            for (int i = 0; i < count; i++)
            {
                result += text;
            }

            Console.WriteLine(result);
            return result;
        }
    }
}
