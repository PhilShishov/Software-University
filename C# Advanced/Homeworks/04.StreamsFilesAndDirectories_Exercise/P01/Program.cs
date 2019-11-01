using System;
using System.IO;
using System.Linq;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"text.txt";
            var reader = new StreamReader(filePath);

            using (reader)
            {
                int count = 0;
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (count % 2 == 0)
                    {
                        string replacedSymbols = ReplaceSpecialCharacters(line);
                        string reversedWords = ReversedWords(replacedSymbols);

                        Console.WriteLine(reversedWords);
                    }

                    line = reader.ReadLine();
                    count++;
                }
            }
        }

        private static string ReversedWords(string replacedSymbols)
        {
            return string.Join(" ", replacedSymbols.Split().Reverse());
        }

        private static string ReplaceSpecialCharacters(string line)
        {
            return line.Replace("-", "@")
                .Replace(",", "@")
                .Replace(".", "@")
                .Replace("!", "@")
                .Replace("?", "@");
        }
    }
}
