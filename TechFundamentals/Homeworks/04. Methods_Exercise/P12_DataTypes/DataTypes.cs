
namespace P12_DataTypes
{
    using System;

    class DataTypes
    {
        static void Main()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "int":
                    int intA = int.Parse(Console.ReadLine());
                    int resultInt = FormatInput(intA);
                    Console.WriteLine(resultInt);
                    break;
                case "real":
                    double doubleA = double.Parse(Console.ReadLine());
                    double resultDouble = FormatInput(doubleA);
                    Console.WriteLine($"{resultDouble:F2}");
                    break;
                case "string":
                    string stringA = Console.ReadLine();
                    string resultString = FormatInput(stringA);
                    Console.WriteLine($"${resultString}$");
                    break;
            }
        }

        private static string FormatInput(string a)
        {
            return a;
        }

        private static double FormatInput(double a)
        {
            double result = a * 1.5;
            return result;
        }

        public static int FormatInput(int a)
        {
            int result = a * 2;
            return result;
        }
    }
}
