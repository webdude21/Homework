namespace LoginWithCookies
{
    using System;
    using System.Web.UI;

    public partial class Logged : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cookie = this.Request.Cookies["LoggedUser"];
            if (cookie == null)
            {
                this.Response.Redirect("~/Login.aspx");
            }
            else
            {
                this.LoggedAsLabel.Text = "Logged in as: " + cookie.Value;
            }
        }
    }
}