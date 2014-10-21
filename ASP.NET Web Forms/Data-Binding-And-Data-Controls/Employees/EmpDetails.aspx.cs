namespace Employees
{
    using System;
    using System.Linq;
    using System.Web.UI;

    using NorthwindData;

    public partial class EmpDetails : Page
    {
        private readonly NorthwindEntities northwindDbContext = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            var employeeId = 0;
            var error = false;
            
            try
            {
                employeeId = int.Parse(this.Request["id"]);
            }
            catch (Exception)
            {
                error = true;   
            }

            if (employeeId < 1 || error)
            {
                this.Response.Redirect("~/Employees.aspx");
                return;
            }

            if (!this.IsPostBack)
            {
                this.DetailsViewEmployee.DataSource = this.northwindDbContext.Employees.ToArray();
                this.DetailsViewEmployee.PageIndex = employeeId - 1;
                this.DataBind();
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("~/Employees.aspx");
        }
    }
}