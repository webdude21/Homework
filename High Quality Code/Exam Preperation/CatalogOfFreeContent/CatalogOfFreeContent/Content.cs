namespace CatalogOfFreeContent
{
    using System;
    using System.Collections.Generic;

    public class Content : IContent
    {
        private string url;

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

        public string URL
        {
            get
            {
                return this.url;
            }

            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString(); // To update the text representation
            }
        }

        public CatalogType Type { get; set; }

        public string TextRepresentation { get; set; }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            var otherContent = obj as Content;
            if (otherContent == null)
            {
                throw new ArgumentException("Object is not a Content");
            }
            var comparisonResul = String.Compare(this.TextRepresentation, otherContent.TextRepresentation, StringComparison.Ordinal);

            return comparisonResul;
        }


        public override string ToString()
        {
            var output = string.Format(
                "{0}: {1}; {2}; {3}; {4}", 
                this.Type, 
                this.Title, 
                this.Author, 
                this.Size, 
                this.URL);

            return output;
        }
    }
}