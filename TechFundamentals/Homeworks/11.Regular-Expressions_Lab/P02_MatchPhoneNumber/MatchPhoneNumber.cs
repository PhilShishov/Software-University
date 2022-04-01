
namespace P02_MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    class MatchPhoneNumber
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var regex = new Regex(@"(\+\d{3}\s\d\s\d{3}\s\d{4})\b|(\+\d{3}-\d-\d{3}-\d{4})\b");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.Write(string.Join(", ", match.Value));
            }
            Console.WriteLine();

        }
    }
}
