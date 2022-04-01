
namespace P07_HTMLParser
{
    using System;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var titleHTML = Regex.Match(input, @"<title>([^\d]+)<\/title>");
            var title = titleHTML.Groups[1].Value;

            Console.WriteLine("Title: {0}", title);

            var bodyHTML = Regex.Match(input, @"<body>(.*?)<\/body>");
            var contentRaw = Regex.Replace(bodyHTML.Groups[1].Value, @"<[^<>]+>?", " ");
            var contentWithoutN = Regex.Replace(contentRaw.ToString(), @"\\n", " ");
            var contentCleaned = Regex.Replace(contentWithoutN.ToString(), @"\s+", " ");
            //var Result = Regex.Replace(content.ToString(), @"-?\d+(\.\d+)?", " ");

            var result = contentCleaned.ToString()
                .TrimEnd(new char[] { ' ', '\t' })
                .TrimStart(new char[] { ' ', '\t' });

            Console.WriteLine($"Content: {result}");
        }
    }
}
