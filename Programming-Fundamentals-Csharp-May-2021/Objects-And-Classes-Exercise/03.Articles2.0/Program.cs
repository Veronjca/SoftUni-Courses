using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> allArticles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] articleArgs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();


                Article newArticle = new Article();

                newArticle.Title = (articleArgs[0]);
                newArticle.Content = (articleArgs[1]);
                newArticle.Author = (articleArgs[2]);

                allArticles.Add(newArticle);
            }

            string orderBy = Console.ReadLine();

            if (orderBy == "title")
            {
                allArticles = allArticles.OrderBy(x => x.Title).ToList();
            }
            else if (orderBy == "content")
            {
                allArticles = allArticles.OrderBy(x => x.Content).ToList();
            }
            else if (orderBy == "author")
            {
                allArticles = allArticles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in allArticles)
            {
                Console.WriteLine(article.ToString());
            }
        }

        class Article
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public string Author { get; set; }

            public override string ToString()
            {
                return $"{Title} - {Content}: {Author}";
            }

        }
    }
}
