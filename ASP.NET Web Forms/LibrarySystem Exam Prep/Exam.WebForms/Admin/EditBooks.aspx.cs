namespace Exam.WebForms.Admin
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class Books : Page
    {
        public Books()
        {
            this.LibraryContext = new ApplicationDbContext();
        }

        public ApplicationDbContext LibraryContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> GridViewBooks_Select()
        {
            return this.LibraryContext.Books.OrderBy(book => book.Id).Include("Category");
        }

        public void GridViewBooks_Delete(int id)
        {
            var item = this.LibraryContext.Categories.Find(id);
            this.LibraryContext.Categories.Remove(item);
            this.LibraryContext.SaveChanges();
        }

        public void GridViewBooks_Update(int id)
        {
            var item = this.LibraryContext.Books.Find(id);
            if (item == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.LibraryContext.SaveChanges();
            }
        }

        public void FormViewIsertBook_InsertItem()
        {
            var item = new Book();
            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.LibraryContext.Books.Add(item);
                this.LibraryContext.SaveChanges();
            }
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.LibraryContext.Categories.OrderBy(b => b.Name);
        }

        protected void DropDownListCategoriesCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
            this.btnWrapper.Visible = false;

            var fv = this.UpdatePanelInsertBook.FindControl("FormViewIsertBook") as FormView;
            fv.Visible = true;
        }
    }
}