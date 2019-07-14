
namespace P05_DigitsLettersandOther
{
    using System;
    using System.Text;

    class DigitsLettersandOther
    {
        static void Main()
        {
            string input = Console.ReadLine();

            StringBuilder sb = new StringBuilder();

            foreach (char symbol in input)
            {                 
                if (char.IsDigit(symbol))
                {
                    sb.Append(symbol);
                }
            }

            sb.AppendLine();

            foreach (char symbol in input)
            {
                if (char.IsLetter(symbol))
                {
                    sb.Append(symbol);
                }
            }

            sb.AppendLine();

            foreach (char symbol in input)
            {
                if (char.IsLetterOrDigit(symbol) == false)
                {
                    sb.Append(symbol);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
