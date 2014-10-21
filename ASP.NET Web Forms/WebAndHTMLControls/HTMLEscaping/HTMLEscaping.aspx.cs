namespace HTMLEscaping
{
    using System;
    using System.Web.UI;

    public partial class HTMLEscaping : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonShowOutput_Click(object sender, EventArgs e)
        {
            var output = this.TextBoxInput.Text;
            this.TextBoxOutput.Text = output;
            this.LabelOutput.Text = this.Server.HtmlEncode(output);
        }
    }
}