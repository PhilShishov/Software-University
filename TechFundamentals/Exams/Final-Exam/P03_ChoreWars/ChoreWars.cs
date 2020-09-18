
namespace P03_ChoreWars
{
    using System;
    using System.Text.RegularExpressions;

    class ChoreWars
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int timeDishes = 0;
            int timeCleaning = 0;
            int timeLaundry = 0;
            int totalMinutes = 0;

            string dishesPattern = @"(?<=<)[a-z0-9]+(?=>)";
            string cleaningPattern = @"(?<=\[)[A-Z0-9]+(?=])";
            string laundryPattern = @"(?<={).+(?=})";

            while (input != "wife is happy")
            {
                Match dishesMatch = Regex.Match(input, dishesPattern);
                Match cleaningMatch = Regex.Match(input, cleaningPattern);
                Match laundryMatch = Regex.Match(input, laundryPattern);

                timeDishes = AddTimeToValidMatch(dishesMatch, timeDishes);
                timeCleaning = AddTimeToValidMatch(cleaningMatch, timeCleaning);
                timeLaundry = AddTimeToValidMatch(laundryMatch, timeLaundry);

                input = Console.ReadLine();
            }

            totalMinutes = timeDishes + timeCleaning + timeLaundry;

            Console.WriteLine($"Doing the dishes - {timeDishes} min.");
            Console.WriteLine($"Cleaning the house - { timeCleaning} min.");
            Console.WriteLine($"Doing the laundry - {timeLaundry} min.");
            Console.WriteLine($"Total - {totalMinutes} min.");
        }

        private static int AddTimeToValidMatch(Match matchType, int time)
        {
            if (matchType.Success)
            {
                string str = matchType.ToString();
                string numsPattern = @"\d";
                MatchCollection nums = Regex.Matches(str, numsPattern);

                foreach (Match match in nums)
                {
                    int num = int.Parse(match.ToString());
                    time += num;
                }
            }

            return time;
        }
    }
}
