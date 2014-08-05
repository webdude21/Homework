namespace CatalogOfFreeContent
{
    using System.Collections.Generic;
    using System.Linq;

    using Wintellect.PowerCollections;

    internal class Catalog : ICatalog
    {
        private readonly OrderedMultiDictionary<string, IContent> title;

        private readonly MultiDictionary<string, IContent> url;

        public Catalog()
        {
            this.title = new OrderedMultiDictionary<string, IContent>(true);
            this.url = new MultiDictionary<string, IContent>(true);
        }

        public void Add(IContent content)
        {
            this.title.Add(content.Title, content);
            this.url.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            var contentToList = from c in this.title[title] select c;

            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string old, string newUrl)
        {
            var theElements = 0;

            var contentToList = this.url[old].ToList();

            foreach (var content in contentToList.Cast<Content>())
            {
                this.title.Remove(content.Title, content);
                theElements++; 
            }

            this.url.Remove(old);

            foreach (var content in contentToList)
            {
                content.URL = newUrl;
            }

            foreach (var content in contentToList)
            {
                this.title.Add(content.Title, content);
                this.url.Add(content.URL, content);
            }

            return theElements;
        }
    }
}