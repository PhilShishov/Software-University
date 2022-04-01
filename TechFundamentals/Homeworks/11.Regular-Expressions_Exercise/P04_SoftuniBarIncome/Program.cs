
namespace P04_SoftuniBarIncome
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string pattern =
                @"^%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$%.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?)\$";

            string input = Console.ReadLine();
            double totalPrice = 0;
            while (input != "end of shift")
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string customerName = match.Groups["customer"].Value;
                    string product = match.Groups["product"].Value;
                    double price = double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["count"].Value);

                    Console.WriteLine($"{customerName}: {product:f2} - {price:f2}");
                    totalPrice += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["count"].Value);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {totalPrice:F2}");
        }
    }
}
