namespace Exam.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class EditBooks : Page
    {
        public EditBooks()
        {
            this.DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Book> GridViewBooks_GetData()
        {
            return this.DbContext.Books.OrderBy(b => b.ID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_UpdateItem(int id)
        {
            var item = this.DbContext.Books.Find(id);
            if (item == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", id));
                return;
            }

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.DbContext.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_DeleteItem(int id)
        {
            var item = this.DbContext.Books.Find(id);
            if (item == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", id));
                return;
            }

            this.DbContext.Books.Remove(item);
            this.DbContext.SaveChanges();
        }

        public void FormViewIsertBook_InsertItem()
        {
            var item = new Book();
            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.DbContext.Books.Add(item);
                this.DbContext.SaveChanges();
            }
        }

        public IQueryable<Category> DropDownListCategoriesCreate_GetData()
        {
            return this.DbContext.Categories.OrderBy(b => b.Name);
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