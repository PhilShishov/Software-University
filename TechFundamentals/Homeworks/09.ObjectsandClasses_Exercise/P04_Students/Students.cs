
namespace P04_Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Students
    {
        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                FirstName = firstName;
                LastName = lastName;
                Grade = grade;
            }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{FirstName} {LastName}: {Grade:F2}";
            }
        }

        static void Main()
        {
            int commandCount = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] input = Console.ReadLine().Split();

                string firstName = input[0];
                string lastName = input[1];
                double grade = double.Parse(input[2]);

                var student = new Student(firstName, lastName, grade);

                students.Add(student);
            }

            foreach (Student student in students.OrderByDescending(s => s.Grade))
            {
                Console.WriteLine(student);
            }

        }
    }
}
