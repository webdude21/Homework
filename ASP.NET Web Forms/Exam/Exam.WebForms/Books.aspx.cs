namespace Exam.WebForms
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Exam.WebForms.App_Data;

    public partial class Books : Page
    {

        public Books()
        {
            this.DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Models.Category> ListViewCategories_GetData()
        {
            return this.DbContext.Categories;
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            var queryString = string.Format("?q={0}", this.TextBoxSearch.Text);
            Response.Redirect("~/Search.aspx" + queryString);
        }
    }
}