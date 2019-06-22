
namespace P11_EncryptSortandPrintArray
{
    using System;
    using System.Text.RegularExpressions;

    class EncryptSortandPrintArray
    {
        static void Main()
        {
            int sequenceStrings = int.Parse(Console.ReadLine());
            int[] numberSequence = new int[sequenceStrings];

            for (int i = 0; i < sequenceStrings; i++)
            {
                int sum = 0;
                string name = Console.ReadLine();
                name = Regex.Replace(name, "[^a-zA-Z]", "");
                name = char.ToUpper(name[0]) + name.Substring(1);

                foreach (char letter in name)
                {
                    if (letter == 'a' || letter == 'e' ||
                        letter == 'o' || letter == 'i' ||
                        letter == 'u' || letter == 'A' ||
                        letter == 'E' || letter == 'O' ||
                        letter == 'I' || letter == 'U')
                    {
                        sum += letter * name.Length;
                    }
                    else
                    {
                        sum += letter / name.Length;
                    }
                }
                numberSequence[i] = sum;
            }
            Array.Sort(numberSequence);

            for (int i = 0; i < numberSequence.Length; i++)
            {
                Console.WriteLine(numberSequence[i] + " ");
            }
        }
    }
}
