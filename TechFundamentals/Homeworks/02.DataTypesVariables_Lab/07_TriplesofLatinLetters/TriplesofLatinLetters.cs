
namespace _07_TriplesofLatinLetters
{
    using System;

    class TriplesofLatinLetters
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());
            //for (int i1 = 0; i1 < n; i1++)
            //    for (int i2 = 0; i2 < n; i2++)
            //        for (int i3 = 0; i3 < n; i3++)
            //        {
            //            char letter1 = (char)('a' + i1);
            //            char letter2 = (char)('a' + i2);
            //            char letter3 = (char)('a' + i3);
            //            Console.WriteLine($"{letter1}{letter2}{letter3}");
            //        }

            int n = int.Parse(Console.ReadLine());
            for (char first = 'a'; first < 'a' + n; first++)
                for (char second = 'a'; second < 'a' + n; second++)
                    for (char third = 'a'; third < 'a' + n; third++)
                    {                        
                        Console.WriteLine($"{first}{second}{third}");
                    }
        }
    }
}
