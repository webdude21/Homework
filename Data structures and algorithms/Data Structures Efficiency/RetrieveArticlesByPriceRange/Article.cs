namespace RetrieveArticlesByPriceRange
{
    using System;

    internal class Article : IComparable<Article>
    {
        public Article(string title, string vendor, ulong barCode, decimal price)
        {
            this.Price = price;
            this.BarCode = barCode;
            this.Vendor = vendor;
            this.Title = title;
        }

        public string Title { get; private set; }

        public string Vendor { get; private set; }

        public ulong BarCode { get; private set; }

        public decimal Price { get; private set; }

        public int CompareTo(Article other)
        {
            return this.Price.CompareTo(other.Price);
        }

        public override string ToString()
        {
            return string.Format(
                "Title: {0}, Vendor: {1}, Bar code: {2}, Price: {3} ", 
                this.Title, 
                this.Vendor, 
                this.BarCode, 
                this.Price);
        }
    }
}