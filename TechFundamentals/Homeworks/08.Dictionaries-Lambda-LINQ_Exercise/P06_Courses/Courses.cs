
namespace P06_Courses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Courses
    {
        static void Main()
        {
            string operation = Console.ReadLine();
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            while (operation != "end")
            {
                List<string> names = operation.Split(':').ToList();

                string courseName = names[0];
                string personName = names[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }
                courses[courseName].Add(personName);

                operation = Console.ReadLine();
            }

            courses = courses.OrderByDescending(x => x.Value.Count).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            foreach (var course in courses)
            {
                string courseName = course.Key;
                int courseCount = course.Value.Count();

                Console.WriteLine($"{courseName.Trim()}: {courseCount}");
                List<string> peopleInCourse = course.Value.ToList();

                peopleInCourse.Sort();

                foreach (var person in peopleInCourse)
                {
                    Console.WriteLine($"-- {person.Trim()}");
                }
            }
        }
    }
}
