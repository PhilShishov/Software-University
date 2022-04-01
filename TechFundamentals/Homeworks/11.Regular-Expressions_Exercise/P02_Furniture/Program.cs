
namespace P02_Furniture
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-Za-z]+)<<(?<price>\d+\.?\d*)!(?<quantity>\d+)";
            List<string> nameList = new List<string>();
            double totalPrice = 0;
            bool enter = false;


            while (true)
            {

                if (input == "Purchase")
                {
                    break;
                }
                Regex regex = new Regex(pattern);
                Match match = regex.Match(input);
                if (match.Success)
                {
                    nameList.Add(match.Groups["name"].Value);
                    totalPrice += double.Parse(match.Groups["price"].Value) * double.Parse(match.Groups["quantity"].Value);
                    enter = true;
                }
                input = Console.ReadLine();

            }
            if (enter == true)
            {
                Console.WriteLine("Bought furniture:");
                Console.WriteLine(string.Join(Environment.NewLine, nameList));
                Console.WriteLine($"Total money spend: {totalPrice:f2}");
            }
            else
            {
                Console.WriteLine("Bought furniture:");
                Console.WriteLine($"Total money spend: {totalPrice:f2}");
            }
        }
    }
}
