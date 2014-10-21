namespace EmployeesWithFormView
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;

    using NorthwindData;

    public partial class Employees : Page
    {
        private readonly NorthwindEntities northwindDbContext = new NorthwindEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.ButtonBack.Visible = false;
            this.FormViewEmployee.Visible = false;

            if (!this.IsPostBack)
            {
                var employees = this.northwindDbContext.Employees.ToArray();
                this.GridViewEmployees.DataSource = employees;
                this.DataBind();
            }
        }

        protected void GridViewEmployees_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedDataKey = this.GridViewEmployees.SelectedDataKey;

            if (selectedDataKey != null)
            {
                var employeeId = Convert.ToInt32(selectedDataKey.Value);
                this.FormViewEmployee.DataSource = new List<Employee> { this.northwindDbContext.Employees.FirstOrDefault(x => x.EmployeeID == employeeId) };
                this.FormViewEmployee.DataBind();
                this.GridViewEmployees.Visible = false;
                this.FormViewEmployee.Visible = true;
                this.ButtonBack.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            this.GridViewEmployees.Visible = true;
            this.FormViewEmployee.Visible = false;
            this.ButtonBack.Visible = false;
        }
    }
}