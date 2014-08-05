namespace CatalogOfFreeContent
{
    using System;

    public class co : IComparable, IContent
    {
        private string url;

        public co(ct type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)acpi.Title];
            this.Author = commandParams[(int)acpi.Author];
            this.Size = long.Parse(commandParams[(int)acpi.Size]);
            this.URL = commandParams[(int)acpi.Url];
        }

        public int CompareTo(object obj)
        {
            if (null == obj)
            {
                return 1;
            }

            var otherContent = obj as co;
            if (otherContent != null)
            {
                var comparisonResul = this.TextRepresentation.CompareTo(otherContent.TextRepresentation);

                return comparisonResul;
            }

            throw new ArgumentException("Object is not a Content");
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

        public ct Type { get; set; }

        public string TextRepresentation { get; set; }

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