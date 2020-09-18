
namespace P04_MeTubeStatistics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MeTubeStatistics
    {
        static void Main()
        {
            var videos = new Dictionary<string, int[]>();

            string input = Console.ReadLine();

            while (input != "stats time")
            {
                if (input.Contains("-"))
                {
                    string[] tokens = input.Split('-');
                    string name = tokens[0];
                    int views = int.Parse(tokens[1]);

                    if (!videos.ContainsKey(name))
                    {
                        videos[name] = new int[2];
                    }
                    videos[name][0] += views;
                }

                else if (input.Contains(':'))
                {
                    string[] tokens = input.Split(':');
                    string like = tokens[0];
                    string name = tokens[1];

                    if (videos.ContainsKey(name))
                    {
                        if (like == "like")
                        {
                            videos[name][1]++;
                        }
                        else if (like == "dislike")
                        {
                            videos[name][1]--;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            if (input == "by views")
            {
                PrintVideosByOrder(videos, 0);
            }

            else if (input == "by likes")
            {
                PrintVideosByOrder(videos, 1);
            }
        }

        private static void PrintVideosByOrder(Dictionary<string, int[]> videos, int indexOfVideoArray)
        {
            foreach (var video in videos.OrderByDescending(v => v.Value[indexOfVideoArray]))
            {
                string name = video.Key;
                int views = video.Value[0];
                int likes = video.Value[1];
                Console.WriteLine($"{name} - {views} views - {likes} likes");
            }
        }
    }
}
