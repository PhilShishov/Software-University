using System;
using System.IO;
using System.Linq;

namespace P02
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"text.txt";
            string[] symbols = new string[] { "-", ",", ".", "!", "?", "'" };

            var reader = new StreamReader(inputFilePath);

            //string[] textLines = File.ReadAllLines(inputFilePath);

            //foreach (var line in textLines)
            //{
            //    int lettersCount = line.Count(char.IsLetter);
            //    int puncsCount = line.Count(char.IsPunctuation);

            //    File.AppendAllText("output.txt", "");
            //    countLine++;
            //}


            using (reader)
            {
                string line = reader.ReadLine();

                var writer = new StreamWriter(@"output.txt");

                using (writer)
                {
                    int countLine = 1;

                    while (line != null)
                    {
                        int countSymbols = 0;
                        int countLetters = 0;

                        foreach (var symbol in line)
                        {
                            if (symbols.Contains(symbol.ToString()))
                            {
                                countSymbols++;
                            }
                            else if (symbol.ToString() != " ")
                            {
                                countLetters++;
                            }
                        }
                        writer.WriteLine($"Line {countLine}: {line} ({countLetters})({countSymbols})");

                        countLine++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
