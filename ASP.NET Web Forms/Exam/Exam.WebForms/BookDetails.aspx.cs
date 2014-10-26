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
            this.DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Book FormViewDetails_GetItem([QueryString("id")] int? bookId)
        {
            var book = this.DbContext.Books.FirstOrDefault(x => x.ID == bookId);

            if (book == null)
            {
                this.Response.Redirect("~/");
            }

            return book;
        }
    }
}