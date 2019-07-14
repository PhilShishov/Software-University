
namespace P03_Substring
{
    using System;

    class Substring
    {
        static void Main()
        {
            string word = Console.ReadLine().ToLower();
            string text = Console.ReadLine();

            int index = text.IndexOf(word);

            while (index != -1)
            {
                text = text.Replace(word, string.Empty);
                index = text.IndexOf(word);
            }

            Console.WriteLine(text);
        }
    }
}
