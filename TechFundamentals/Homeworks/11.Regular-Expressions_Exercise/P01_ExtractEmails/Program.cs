
namespace P01_ExtractEmails
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string emailPattern = @"(?<=\s)([A-Za-z0-9]+[-._]*[A-Za-z0-9]+)@([A-Za-z0-9]+(([-.]*)[A-Za-z]+)*\.[a-z]{2,})";

            string input = Console.ReadLine();

            MatchCollection matchCol = Regex.Matches(input, emailPattern);

            foreach (Match item in matchCol)
            {
                Console.WriteLine(item.Value);
            }
        }        
    }
}
