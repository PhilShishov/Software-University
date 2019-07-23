
namespace P01_StudentSystem
{
    using Data;
    using Data.Models;

    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            string[] courseNames =
            {
                "Advanced",
                "Fundamentals",
                "Databases",
                "Basics"
            };

            string[] languages =
            {
                "C#",
                "Java",
                "JS",
                "Python",
                "PHP"
            };

            List<Course> allCourses = GenerateCourses(courseNames, languages);
            int numberOfSeededCourses = SeedCourses(allCourses);
            Console.WriteLine(numberOfSeededCourses);
        }

        private static List<Course> GenerateCourses(string[] courses, string[] languages)
        {
            var initialPrice = 0;
            var allCourses = new List<Course>();

            foreach (string language in languages)
            {
                foreach (string module in courses)
                {
                    string courseName = $"{language} {module}";

                    var course = new Course
                    {
                        Name = courseName,
                        Description = $"Description for the {courseName}",
                        Price = initialPrice
                    };

                    allCourses.Add(course);

                    initialPrice += 25;
                }
            }

            return allCourses;
        }
        private static int SeedCourses(List<Course> coursesToSeed)
        {
            using (var context = new StudentSystemContext())
            {
                context.AddRange(coursesToSeed);

                return context.SaveChanges();
            }
        }
    }
}
