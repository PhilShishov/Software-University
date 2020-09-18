using System;

namespace P05
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string stringOne = Console.ReadLine();
            string stringTwo = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            int result = dateModifier.CalculateDayDifference(stringOne, stringTwo);
            Console.WriteLine(result);
        }
    }
}
