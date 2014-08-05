namespace CatalogOfFreeContent.Commands
{
    using System.Collections.Generic;

    using CatalogOfFreeContent.Contracts;

    public class AddContent
    {
        private readonly CatalogType catalogType;

        private readonly IList<string> parameters;

        private readonly ICatalog catalog;

        public AddContent(CatalogType catalogType, IList<string> parameters, ICatalog catalog)
        {
            this.catalogType = catalogType;
            this.parameters = parameters;
            this.catalog = catalog;
        }

        public string ExecuteCommand()
        {
            this.catalog.Add(new Content(this.catalogType, this.parameters));
            return "Book added";           
        }
    }
}
