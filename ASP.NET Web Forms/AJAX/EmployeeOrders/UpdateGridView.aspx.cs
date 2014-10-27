namespace EmployeeOrders
{
    using System;
    using System.Threading;
    using System.Web.UI;

    public partial class UpdateGridView : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void GridViewOrders_Load(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
        }

    }
}