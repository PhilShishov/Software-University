
namespace P04_PasswordValidator
{
    using System;

    class PasswordValidator
    {
        static void Main()
        {
            string password = Console.ReadLine();

            bool isBetween6And10Symbols = CheckLengthOfPassword(password);

            if (isBetween6And10Symbols == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool containsOnlyDigitsAndLetters = CheckContainsOnlyDigitsAndLetters(password);

            if (containsOnlyDigitsAndLetters == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool containsMinTwoDigits = CheckMinTwoDigits(password);

            if (containsMinTwoDigits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isBetween6And10Symbols && containsOnlyDigitsAndLetters && containsMinTwoDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckMinTwoDigits(string password)
        {
            int count = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (char.IsDigit(symbol))
                {
                    count++;
                }
            }

            return count >= 2 ? true : false;
        }

        private static bool CheckContainsOnlyDigitsAndLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (!char.IsLetterOrDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckLengthOfPassword(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }
       
    }
}
