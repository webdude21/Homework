namespace Exam.WebForms
{
    using System.Web.UI;

    using Exam.WebForms.App_Data;

    public class BasePage : Page
    {
        public BasePage()
        {
            this.LibraryDbContext = new ApplicationDbContext();
        }
        public ApplicationDbContext LibraryDbContext { get; set; }
    }
}