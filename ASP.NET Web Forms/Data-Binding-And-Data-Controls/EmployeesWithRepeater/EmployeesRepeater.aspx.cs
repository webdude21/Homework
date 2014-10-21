namespace EmployeesWithRepeater
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using NorthwindData;

    public partial class EmployeesRepeater : Page
    {
        private readonly NorthwindEntities northwindDbContext = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.RepeaterEmployees.DataSource = this.northwindDbContext.Employees.ToList();
                this.DataBind();
            }
        }

        protected string GetImage(byte[] photo)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String(photo);
        }
    }
}