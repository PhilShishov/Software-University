using System;
using System.IO;

namespace P01
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = Path.Combine("Files", "Input.txt");
            StreamReader reader = new StreamReader(filePath);

            using (reader)
            {
                StreamWriter writer = new StreamWriter(Path.Combine("Files", "Output.txt"));

                using (writer)
                {
                    int counter = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(line);
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
