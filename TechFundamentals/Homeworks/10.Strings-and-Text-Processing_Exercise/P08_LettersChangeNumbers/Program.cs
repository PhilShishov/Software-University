
namespace P08_LettersChangeNumbers
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            double totalSum = 0;

            foreach (var item in input)
            {
                if (item.Length > 1)
                {
                    double sum = 0;

                    char firstIndex = item[0];
                    char secondIndex = item[item.Length - 1];

                    double number = 0.0;

                    if (item.Length > 2)
                    {
                        try
                        {
                            number = double.Parse(item.Substring(1, item.Length - 2));
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }

                    sum = GetFirstSum(firstIndex, number);
                    sum = GetSecondSum(secondIndex, sum);
                    totalSum += sum;
                }
            }

            Console.WriteLine($"{totalSum:f2}");
        }

        private static double GetSecondSum(char secondIndex, double sum)
        {
            double secondSum = sum;
            double pos = GetPosition(secondIndex);

            if (secondIndex >= 'a' && secondIndex <= 'z')
            {
                secondSum += pos;
            }
            else if (secondIndex >= 'A' && secondIndex <= 'Z')
            {
                secondSum -= pos;
            }

            return secondSum;
        }

        private static double GetFirstSum(char firstIndex, double number)
        {
            double sum = 0;
            double pos = GetPosition(firstIndex);

            if (firstIndex >= 'a' && firstIndex <= 'z')
            {
                sum = number * pos;
            }
            else if (firstIndex >= 'A' && firstIndex <= 'Z')
            {
                sum = number / pos;
            }

            return sum;
        }

        private static double GetPosition(char index)
        {
            double count = 0;

            char chek = char.ToLower(index);

            for (int i = 'a'; i <= 'z'; i++)
            {
                if (i > chek)
                {
                    break;
                }
                count++;
            }
            return count;
        }
    }
}
