using System;
using System.IO;

namespace P04
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePathOne = Path.Combine("Files", "FileOne.txt");
            string filePathTwo = Path.Combine("Files", "FileTwo.txt");

            using (var firstReader = new StreamReader(filePathOne))
            {
                using (var secondReader = new StreamReader(filePathTwo))
                {
                    using (var writer = new StreamWriter(Path.Combine("Files", "Output.txt")))
                    {
                        while (true)
                        {
                            string firstLine = firstReader.ReadLine();
                            string secondLine = secondReader.ReadLine();

                            if (firstLine == null && secondLine == null)
                            {
                                break;
                            }

                            writer.WriteLine(firstLine);
                            writer.WriteLine(secondLine);
                        }
                    }
                }
            }
        }
    }
}
