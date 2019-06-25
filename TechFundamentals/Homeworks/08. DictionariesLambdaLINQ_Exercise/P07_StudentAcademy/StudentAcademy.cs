
namespace P07_StudentAcademy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentAcademy
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var studentGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades[name] = new List<double>();
                }

                studentGrades[name].Add(grade);
            }

            var filteredGrades = studentGrades
                .Where(x => x.Value.Average() >= 4.50)
                .OrderByDescending(x => x.Value.Average())
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in filteredGrades)
            {
                string name = kvp.Key;
                List<double> grades = kvp.Value;

                Console.WriteLine($"{name} -> {grades.Average():F2}");

            }
        }
    }
}
