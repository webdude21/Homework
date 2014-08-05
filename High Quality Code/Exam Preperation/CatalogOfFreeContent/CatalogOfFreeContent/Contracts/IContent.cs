namespace CatalogOfFreeContent.Contracts
{
    using System;

    public interface IContent : IComparable
    {
        string Title { get; set; }

        string Author { get; set; }

        long Size { get; set; }

        string URL { get; set; }

        CatalogType Type { get; set; }

    }
}