using System;

namespace P01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());

                if (n < 0)
                {
                    throw new Exception();
                }
                else
                {
                    double result = (Math.Sqrt(n));

                    Console.WriteLine(result);

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }

            catch (Exception)
            {
                Console.WriteLine("Invalid number");
            }

            finally
            {
                Console.WriteLine("Good bye");
            }
        }
    }
}
