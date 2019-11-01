using System;
using System.IO;

namespace P05
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new FileStream("Files\\sliceMe.txt", FileMode.Open);

            using (inputFile)
            {
                long size = inputFile.Length;
                int partSize = (int)Math.Ceiling(size / 4.0);
                byte[] buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"files\\Part-{i}.txt", FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, partSize);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
