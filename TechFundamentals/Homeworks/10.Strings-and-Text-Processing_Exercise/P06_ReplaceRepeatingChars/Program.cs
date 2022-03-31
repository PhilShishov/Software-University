
namespace P06_ReplaceRepeatingChars
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            text.Distinct()
                .Select(c => c.ToString())
                .ToList()
                .ForEach(c =>
                {
                    while (text.Contains(c + c))
                    {
                        text = text.Replace(c + c, c);
                    }
                });

            Console.WriteLine(text);
        }
    }
}
