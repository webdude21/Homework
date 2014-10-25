namespace LoginWithCookies
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            var cookie = new HttpCookie("LoggedUser", this.TextBoxLogin.Text) { Expires = DateTime.Now.AddMinutes(1) };
            Response.Cookies.Add(cookie);
            Response.Redirect("~/Logged.aspx");
        }
    }
}