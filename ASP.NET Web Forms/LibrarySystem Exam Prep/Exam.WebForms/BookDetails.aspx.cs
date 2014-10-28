namespace Exam.WebForms
{
    using System;
    using System.Linq;
    using System.Web.ModelBinding;
    using System.Web.UI;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class BookDetails : Page
    {
        public BookDetails()
        {
            this.LibraryDbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext LibraryDbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Book FormViewBook_Select([QueryString("id")] int? bookId)
        {
            var book = this.LibraryDbContext.Books.FirstOrDefault(b => b.Id == bookId);

            if (book == null)
            {
                this.Response.Redirect("~/");
            }

            return book;
        }
    }
}