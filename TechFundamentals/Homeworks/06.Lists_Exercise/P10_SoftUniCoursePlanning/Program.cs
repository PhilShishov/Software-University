
namespace P10_SoftUniCoursePlanning
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            List<string> lessons = Console.ReadLine()
                .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "course start")
                {
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{lessons[i]}");
                    }
                    break;
                }
                string[] line = command.Split(':').ToArray();
                switch (line[0])
                {
                    case "Add":
                        if (lessons.Contains(line[1]) == false)
                        {
                            lessons.Add(line[1]);
                        }
                        break;
                    case "Insert":
                        int index = int.Parse(line[2]);
                        if (lessons.Contains(line[1]) == false)
                        {
                            lessons.Insert(index, line[1]);
                        }
                        break;
                    case "Remove":
                        if (lessons.Contains(line[1]) == true)
                        {
                            lessons.Remove(line[1]);
                            if (lessons.Contains(line[1] + "-Exercise") == true)
                            {
                                lessons.Remove(line[1] + "-Exercise");
                            }
                        }
                        break;
                    case "Swap":
                        string first = line[1];
                        string second = line[2];
                        int firstIndex = 0;
                        int secondIndex = 0;
                        if (lessons.Contains(line[1]) == true && lessons.Contains(line[2]) == true)
                        {

                            for (int i = 0; i < lessons.Count; i++)
                            {
                                if (lessons[i] == first)
                                {
                                    firstIndex = i;

                                }
                                if (lessons[i] == second)
                                {
                                    secondIndex = i;

                                }
                            }

                            if (lessons.Contains(line[1] + "-Exercise") == true 
                                && lessons.Contains(line[2] + "-Exercise") == true)
                            {
                                string changer = lessons[firstIndex + 1];
                                lessons[firstIndex + 1] = lessons[secondIndex + 1];
                                lessons[secondIndex + 1] = changer;
                                lessons[firstIndex] = second;
                                lessons[secondIndex] = first;
                            }
                            else if (lessons.Contains(line[1] + "-Exercise") == true 
                                && lessons.Contains(line[2] + "-Exercise") == false)
                            {
                                string copy = lessons[firstIndex + 1];
                                lessons[firstIndex] = second;
                                lessons[secondIndex] = first;
                                lessons.Remove(lessons[firstIndex + 1]);
                                for (int i = 0; i < lessons.Count; i++)
                                {
                                    if (lessons[i] == first)
                                    {
                                        lessons.Insert(i + 1, copy);
                                    }
                                }

                            }
                            else if (lessons.Contains(line[1] + "-Exercise") == false 
                                && lessons.Contains(line[2] + "-Exercise") == true)
                            {
                                string copy = lessons[secondIndex + 1];
                                lessons[firstIndex] = second;
                                lessons[secondIndex] = first;
                                lessons.Remove(lessons[secondIndex + 1]);
                                for (int i = 0; i < lessons.Count; i++)
                                {
                                    if (lessons[i] == second)
                                    {
                                        lessons.Insert(i + 1, copy);
                                    }
                                }

                            }
                            else
                            {
                                lessons[firstIndex] = second;
                                lessons[secondIndex] = first;
                            }
                        }
                        break;
                    case "Exercise":
                        if (lessons.Contains(line[1]) == true 
                            && lessons.Contains(line[1] + "-Exercise") == false)
                        {
                            for (int i = 0; i < lessons.Count; i++)
                            {
                                if (lessons[i] == line[1])
                                {
                                    lessons.Insert(i + 1, line[1] + "-Exercise");
                                }
                            }
                        }
                        else if (lessons.Contains(line[1]) == false)
                        {
                            lessons.Add(line[1]);
                            lessons.Add(line[1] + "-Exercise");
                        }
                        break;
                }
            }
        }
    }
}
