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
            this.LibraryContext = new ApplicationDbContext();
        }

        public ApplicationDbContext LibraryContext { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Category> GridViewCategories_Select()
        {
            return this.LibraryContext.Categories.OrderBy(category => category.Id);
        }

        public void GridViewCategories_Delete(int id)
        {
            var item = this.LibraryContext.Categories.Find(id);
            this.LibraryContext.Categories.Remove(item);
            this.LibraryContext.SaveChanges();
        }

        public void GridViewCategories_Update(int id)
        {
            var item = this.LibraryContext.Categories.Find(id);
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
    }
}