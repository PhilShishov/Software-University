
namespace P03_MatchDates
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string text = Console.ReadLine();
            var regex = @"\b(?<day>\d{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>\d{4})\b";
            MatchCollection dates = Regex.Matches(text, regex);
            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;
                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
