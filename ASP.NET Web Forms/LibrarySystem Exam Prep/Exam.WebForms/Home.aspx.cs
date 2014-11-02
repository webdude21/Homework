namespace Exam.WebForms
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Exam.WebForms.Models;

    public partial class Home : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Category> Select_Categories()
        {
            return this.LibraryDbContext.Categories.Include("Books");
        }

        public IQueryable<Book> Select_Books()
        {
            return this.LibraryDbContext.Books;
        }

        protected void SearchButton_OnClick(object sender, EventArgs e)
        {
            var searchQuery = this.TextBoxSearch.Text;

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                this.Response.Redirect("~/Search.aspx?q=" + searchQuery);
            }
        }
    }
}