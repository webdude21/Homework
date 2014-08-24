namespace RetrieveArticlesByPriceRange
{
    using Wintellect.PowerCollections;

    internal class ArticleStorage
    {
        private readonly OrderedMultiDictionary<decimal, Article> internalStorage;

        public ArticleStorage(bool allowDuplicateValues)
        {
            this.internalStorage = new OrderedMultiDictionary<decimal, Article>(allowDuplicateValues);
        }

        public void Add(Article item)
        {
            this.internalStorage.Add(item.Price, item);
        }

        public void Remove(Article item)
        {
            this.internalStorage.Remove(item.Price, item);
        }

        public OrderedMultiDictionary<decimal, Article>.View SelectRange(
            decimal from, 
            bool fromInclusive, 
            decimal to, 
            bool toInclusive)
        {
            return this.internalStorage.Range(from, fromInclusive, to, toInclusive);
        }
    }
}