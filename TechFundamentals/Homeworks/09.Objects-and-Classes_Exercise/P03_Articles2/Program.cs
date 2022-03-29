
namespace P03_Articles2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            int commandCount = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < commandCount; i++)
            {
                string[] articleProps = Console.ReadLine().Split(", ");

                string title = articleProps[0];
                string content = articleProps[1];
                string author = articleProps[2];

                var article = new Article(title, content, author);

                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                foreach (Article article in articles.OrderBy(a => a.Title))
                {
                    Console.WriteLine(article);
                }
            }

            else if (criteria == "content")
            {
                foreach (Article article in articles.OrderBy(a => a.Content))
                {
                    Console.WriteLine(article);
                }
            }

            if (criteria == "author")
            {
                foreach (Article article in articles.OrderBy(a => a.Author))
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}
