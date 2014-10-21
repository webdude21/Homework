namespace EmployeesWithListView
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using NorthwindData;

    public partial class EmployeesWithListView : Page
    {
        private readonly NorthwindEntities northwindDbContext = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ListViewEmplyees.DataSource = this.northwindDbContext.Employees.ToList();
                this.DataBind();
            }
        }
    }
}