
namespace P01_MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    class MatchFullName
    {
        static void Main()
        {
            string names = Console.ReadLine();            

            string regexPattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matchedNames = Regex.Matches(names, regexPattern);

            foreach (Match name in matchedNames)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}
