namespace ClientInfo
{
    using System;
    using System.Web.UI;

    public partial class ClientInfo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralOutput.Text += "IP Address: " + this.Request.UserHostAddress + "<br/>";
            this.LiteralOutput.Text += "Browser Type: " + Request.Browser.Type + "<br/>";
        }

    }
}