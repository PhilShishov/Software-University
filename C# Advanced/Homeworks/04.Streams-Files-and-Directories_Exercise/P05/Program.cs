using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (FileInfo file in allFiles)
            {
                double size = file.Length / 1024d;
                string fileName = file.Name;
                string extension = file.Extension;

                if (!dirInfo.ContainsKey(extension))
                {
                    dirInfo.Add(extension, new Dictionary<string, double>());
                }

                if (!dirInfo[extension].ContainsKey(fileName))
                {
                    dirInfo[extension].Add(fileName, size);
                }
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";

            var sortedDictionary = dirInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var (extension, value) in sortedDictionary)
            {
                File.AppendAllText(path, extension + Environment.NewLine);

                foreach (var (filename, size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path, $"--{filename} - {Math.Round(size, 3)}kb");
                }
            }
        }
    }
}
