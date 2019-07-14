using System;
using System.Collections.Generic;
using System.Linq;

namespace P03_Articles2
{
    class Articles2
    {
        public class Article
        {
            public Article(string title, string content, string author)
            {
                Title = title;
                Content = content;
                Author = author;
            }

            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }
        }

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
