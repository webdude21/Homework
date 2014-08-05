namespace CatalogOfFreeContent
{
    using System.Collections.Generic;
    using System.Linq;

    using CatalogOfFreeContent.Contracts;

    using Wintellect.PowerCollections;

    internal class Catalog : ICatalog
    {
        private readonly OrderedMultiDictionary<string, IContent> contentByTitle;

        private readonly MultiDictionary<string, IContent> contentByUrl;

        public Catalog()
        {
            this.contentByTitle = new OrderedMultiDictionary<string, IContent>(true);
            this.contentByUrl = new MultiDictionary<string, IContent>(true);
        }

        public void Add(IContent content)
        {
            this.contentByTitle.Add(content.Title, content);
            this.contentByUrl.Add(content.URL, content);
        }

        public IEnumerable<IContent> GetListContent(string title, int numberOfContentElementsToList)
        {
            var contentToList = from contentItem in this.contentByTitle[title] select contentItem;
            return contentToList.Take(numberOfContentElementsToList);
        }

        public int UpdateContent(string oldUrl, string newUrl)
        {
            var theElements = 0;

            var contentToList = this.contentByUrl[oldUrl].ToList();

            foreach (var content in contentToList.Cast<Content>())
            {
                this.contentByTitle.Remove(content.Title, content);
                theElements++; 
            }

            this.contentByUrl.Remove(oldUrl);

            foreach (var content in contentToList)
            {
                content.URL = newUrl;
                this.contentByTitle.Add(content.Title, content);
                this.contentByUrl.Add(content.URL, content);
            }

            return theElements;
        }
    }
}