
namespace P02_Articles
{
    using System;

    class Program
    {
        static void Main()
        {
            string[] articleProps = Console.ReadLine().Split(", ");

            string title = articleProps[0];
            string content = articleProps[1];
            string author = articleProps[2];

            Article article = new Article(title, content, author);

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] input = Console.ReadLine().Split(": ");

                string command = input[0];

                if (command == "Edit")
                {
                    string newContent = input[1];

                    article.Edit(newContent);
                }

                else if (command == "ChangeAuthor")
                {
                    string newAuthor = input[1];

                    article.ChangeAuthor(newAuthor);
                }

                else if (command == "Rename")
                {
                    string newTitle = input[1];

                    article.Rename(newTitle);
                }
            }

            Console.WriteLine(article);

        }
    }
}
