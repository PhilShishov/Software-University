
namespace _04_ReverseArrayofStrings
{
    using System;
    using System.Linq;

    class ReverseArrayofStrings
    {
        static void Main()
        {
            //string stringsAsText = Console.ReadLine();
            //string[] strings = stringsAsText.Split();

            //for (int i = strings.Length - 1; i >= 0; i--)
            //{
            //    Console.Write(strings[i] + " ");
            //}
            //Console.WriteLine();

            string[] texts = Console.ReadLine().Split();

            //texts = texts.Reverse().ToArray();

            for (int i = 0; i < texts.Length / 2; i++)
            {
                string firstText = texts[i];
                int indexOfReversedCell = texts.Length - i - 1;

                texts[i] = texts[indexOfReversedCell];
                texts[indexOfReversedCell] = firstText; 
            }
        }
    }
}
