using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Print("cat");
            Console.WriteLine();
        }

        static void Print(string s)
        {
            if (s.Length <= 1)
            {
                Console.Write(s);
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    string a = s.Substring(i + 1);
                    string b = s.Substring(0, i);
                    Print(a + b);
                }

            }
        }
    }
}
