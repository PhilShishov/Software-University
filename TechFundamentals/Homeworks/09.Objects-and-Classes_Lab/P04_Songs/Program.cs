
namespace P04_Songs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main()
        {
            int songCount = int.Parse(Console.ReadLine());

            List<Song> songs = new List<Song>();

            for (int i = 0; i < songCount; i++)
            {
                string[] data = Console.ReadLine().Split("_");

                string type = data[0];
                string name = data[1];
                string time = data[2];

                var song = new Song()
                {
                    TypeList = type,
                    Name = name,
                    Time = time
                };

                songs.Add(song);
            }

            string typeList = Console.ReadLine();

            if (typeList == "all")
            {
                foreach (Song song in songs)
                {
                    Console.WriteLine(song.Name);
                }
                return;
            }
            else
            {
                foreach (Song song in songs)
                {
                    if (song.TypeList == typeList)
                    {
                        Console.WriteLine(song.Name);
                    }
                }
            }

            //List<Song> filteredSongs = songs
            //    .Where(s => s.TypeList == typeList)
            //    .ToList();

            //foreach (Song song in filteredSongs)
            //{
            //    Console.WriteLine(song.Name);
            //}
        }
    }
}
