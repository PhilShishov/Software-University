
namespace P04_TextFilter
{
    using System;

    class TextFilter
    {
        static void Main()
        {
            string[] banWords = Console
                .ReadLine()
                .Split(new[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries);

            string text = Console.ReadLine();

            foreach (var banWord in banWords)
            {
                if (text.Contains(banWord))
                {
                    var replacement = new string('*', banWord.Length);
                    text = text.Replace(banWord, replacement);
                }
            }

            Console.WriteLine(text);
        }
    }
}
