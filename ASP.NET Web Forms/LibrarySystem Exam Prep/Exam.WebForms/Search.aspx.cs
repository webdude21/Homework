namespace Exam.WebForms
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class Search : Page
    {
        public Search()
        {
            this.LibraryDbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext LibraryDbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralSearchQuery.Text = string.Format("\"{0}\"", this.Request.QueryString["q"]);
        }

        public IEnumerable<Book> ListView_SelectBooks([QueryString("q")] string searchQuery)
        {
            return this.LibraryDbContext.Books.Where(b => b.Title.Contains(searchQuery) || b.Author.Contains(searchQuery))
                    .Include("Category");
        }
    }
}