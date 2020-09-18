
namespace P01_ValidUsernames
{
    using System;
    using System.Collections.Generic;

    class ValidUsernames
    {
        static void Main()
        {
            string[] usernames = Console.ReadLine().Split(", ");

            var validUsernames = new List<string>();

            foreach (var username in usernames)
            {
                if (username.Length >= 3 && username.Length <= 16)
                {
                    bool validateContent = ValidateUserNameContent(username);

                    if (validateContent)
                    {
                        validUsernames.Add(username);
                    }
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
        }

        private static bool ValidateUserNameContent(string username)
        {
            foreach (var symbol in username)
            {
                if (char.IsLetterOrDigit(symbol) || symbol == '_' || symbol == '-')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }
    }
}
