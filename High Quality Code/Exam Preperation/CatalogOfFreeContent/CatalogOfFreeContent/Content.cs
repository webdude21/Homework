namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;

    using CatalogOfFreeContent.Contracts;

    public class Content : IContent
    {
        public Content(CatalogType type, IList<string> commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)Acpi.Title];
            this.Author = commandParams[(int)Acpi.Author];
            this.Size = long.Parse(commandParams[(int)Acpi.Size]);
            this.URL = commandParams[(int)Acpi.Url];
        }

        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        public string URL { get; set; }

        public CatalogType Type { get; set; }

        public int CompareTo(object obj)
        {
            var otherContent = obj as Content;

            if (otherContent == null)
            {
                throw new ArgumentException("Object is not a Content");
            }

            return string.Compare(this.ToString(), otherContent.ToString(), StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return string.Format(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type, 
                this.Title, 
                this.Author, 
                this.Size, 
                this.URL);
        }
    }
}