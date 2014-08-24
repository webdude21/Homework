namespace RetrieveArticlesByPriceRange
{
    using System;

    internal class RetrieveArticlesByPriceRange
    {
        private static void Main()
        {
            var articleStorage = new ArticleStorage(true);
            articleStorage.Add(new Article("Gold", "Victory", 12451255, 5.4m));
            articleStorage.Add(new Article("One", "Victory", 12451254, 4.4m));
            articleStorage.Add(new Article("Light", "Victory", 12451253, 3.4m));
            articleStorage.Add(new Article("Heavy", "Victory", 12451251, 2.4m));

            foreach (var item in articleStorage.SelectRange(3.4m, true, 5.4m, true))
            {
                Console.WriteLine(item);
            }
        }
    }
}