namespace Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using NorthwindData;

    public partial class Employees : Page
    {
        private readonly NorthwindEntities northwindDbContext = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.GridViewEmployees.DataSource = this.northwindDbContext.Employees.ToArray();
                this.DataBind();
            }
        }
    }
}