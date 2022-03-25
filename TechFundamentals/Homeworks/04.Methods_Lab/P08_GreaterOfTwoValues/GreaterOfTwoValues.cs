
namespace P08_GreaterOfTwoValues
{
    using System;

    class GreaterOfTwoValues
    {
        static void Main()
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {
                case "int":
                    int intA = int.Parse(Console.ReadLine());
                    int intB = int.Parse(Console.ReadLine());
                    int resultInt = GetMax(intA, intB);
                    Console.WriteLine(resultInt);
                    break;
                case "char":
                    char charA = char.Parse(Console.ReadLine());
                    char charB = char.Parse(Console.ReadLine());                   
                    char resultChar = GetMax(charA, charB);
                    Console.WriteLine(resultChar);
                    break;
                case "string":
                    string stringA = Console.ReadLine();
                    string stringB = Console.ReadLine();
                    string resultString = GetMax(stringA, stringB);
                    Console.WriteLine(resultString);
                    break;
            }

        }
        public static int GetMax(int a, int b)
        {
            return Math.Max(a, b);            
        }

        public static char GetMax(char a, char b)
        {         
            return (char)Math.Max(a, b);
        }

        public static string GetMax(string a, string b)
        {
            int comparison = a.CompareTo(b);

            if (comparison > 0)
            {
                return a;
            }

            else
            {
                return b;
            }
        }
    }
}
