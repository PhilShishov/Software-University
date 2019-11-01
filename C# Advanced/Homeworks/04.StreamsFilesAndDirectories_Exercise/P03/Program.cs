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
            string textPath = "text.txt";
            string wordsPath = "words.txt";

            string[] textLines = File.ReadAllLines(textPath);
            string[] wordsLines = File.ReadAllLines(wordsPath);

            Dictionary<string, int> listOfWords = new Dictionary<string, int>();

            foreach (var word in wordsLines)
            {
                if (!listOfWords.ContainsKey(word))
                {
                    listOfWords.Add(word.ToLower(), 0);
                }
            }

            foreach (var line in textLines)
            {
                string[] words = line.Split(new char[] { ' ', '-', ',', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    if (listOfWords.ContainsKey(word.ToLower()))
                    {
                        listOfWords[word.ToLower()]++;
                    }
                }
            }

            foreach (var kvp in listOfWords)
            {
                File.AppendAllText("actualResult.txt", $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }

            foreach (var kvp in listOfWords.OrderByDescending(w => w.Value))
            {
                File.AppendAllText("expectedResult.txt", $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }
        }
    }
}
