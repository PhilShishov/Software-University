
namespace P03_ExtractFile
{
    using System;
    using System.IO;
    using System.Linq;

    class ExtractFile
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split("\\")
                .ToArray();

            var last = input[^1];

            // Solution 1 - Path
            string fileName = Path.GetFileNameWithoutExtension(last);
            string fileExt = Path.GetExtension(last).Replace(".", "");

            //Solution 2 - Substring
            //string fileExt = last.Substring(last.LastIndexOf('.') + 1);
            //string fileName = last.Substring(0, last.LastIndexOf($".{fileExt}"));

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExt}");

        }
    }
}
