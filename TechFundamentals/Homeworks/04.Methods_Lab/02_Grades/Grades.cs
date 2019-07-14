
namespace P02_Grades
{
    using System;

    class Grades
    {
        static void Main()
        {
            double grade = double.Parse(Console.ReadLine());

            PrintGrade(grade);
        }

        public static void PrintGrade(double grade)
        {
            if (grade >= 5.50 && grade <= 6.00 )
            {
                Console.WriteLine("Excellent");
            }
            else if (grade >= 4.50 )
            {
                Console.WriteLine("Very good");
            }
            else if (grade >= 3.50)
            {
                Console.WriteLine("Good");
            }
            else if (grade >= 3.00)
            {
                Console.WriteLine("Poor");
            }
            else if (grade >= 2.00)
            {
                Console.WriteLine("Fail");
            }
        }
    }
}
