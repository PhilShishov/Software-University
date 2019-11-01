using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace P03
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> listOfWords = new Dictionary<string, int>();

            string wordsPath = Path.Combine("Files", "words.txt");
            string textPath = Path.Combine("Files", "text.txt");

            using (var reader = new StreamReader(wordsPath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] words = line.Split();
                    foreach (var word in words)
                    {
                        if (!listOfWords.ContainsKey(word))
                        {
                            listOfWords.Add(word.ToLower(), 0);
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            using (var reader = new StreamReader(textPath))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string[] words = line.Split(new char[] { ' ', '-', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var word in words)
                    {
                        if (listOfWords.ContainsKey(word.ToLower()))
                        {
                            listOfWords[word.ToLower()]++;
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            StreamWriter writer = new StreamWriter(Path.Combine("Files", "Output.txt"));

            using (writer)
            {

                foreach (var word in listOfWords.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
