namespace Exam.WebForms.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using Exam.WebForms.App_Data;
    using Exam.WebForms.Models;

    public partial class EditCategories : Page
    {
        public EditCategories()
        {
            this.DbContext = new ApplicationDbContext();
        }

        public ApplicationDbContext DbContext { get; set; }

        public IQueryable<Category> ListViewCategories_GetData()
        {
            return this.DbContext.Categories.OrderBy(c => c.ID);
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_DeleteItem(int ID)
        {
            var item = this.DbContext.Categories.Find(ID);
            this.DbContext.Categories.Remove(item);
            this.DbContext.SaveChanges();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewCategories_UpdateItem(int ID)
        {
            var item = this.DbContext.Categories.Find(ID);
            if (item == null)
            {
                // The item wasn't found
                this.ModelState.AddModelError(string.Empty, string.Format("Item with id {0} was not found", ID));
                return;
            }

            this.TryUpdateModel(item);
            if (this.ModelState.IsValid)
            {
                this.DbContext.SaveChanges();
            }
        }

        public void ListViewCategories_InsertItem()
        {
            var item = new Category();
            this.TryUpdateModel(item);

            if (this.ModelState.IsValid)
            {
                this.DbContext.Categories.Add(item);
                this.DbContext.SaveChanges();
            }
        }

        protected void LinkButtonInsert_Click(object sender, EventArgs e)
        {
        }
    }
}