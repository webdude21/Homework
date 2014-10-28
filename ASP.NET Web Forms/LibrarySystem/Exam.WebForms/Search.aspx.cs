namespace Exam.WebForms
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class Search : Page
    {
        public Search()
        {
            this.DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> SearchResultsRepeater_GetData([QueryString("q")] string query)
        {
            this.LiteralSearchQuery.Text = string.Format("''{0}''", query);
            return this.DbContext.Books.Where(a => a.Author.Contains(query) || a.Title.Contains(query));
        }
    }
}