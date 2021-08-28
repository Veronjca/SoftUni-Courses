using System;
using System.Linq;

namespace _02.Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int numberOfCommands = int.Parse(Console.ReadLine());

            Article newArticle = new Article(article[0], article[1], article[2]);

            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] commands = Console.ReadLine()
                .Split(": ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                if (commands[0] == "Edit")
                {
                    newArticle.Edit(commands[1]);
                }
                else if (commands[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(commands[1]);
                }
                else if (commands[0] == "Rename")
                {
                    newArticle.ChangeTitle(commands[1]);
                }

            }

            Console.WriteLine(newArticle.ToString()); 
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article (string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public  void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void ChangeTitle(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }

    }
}
