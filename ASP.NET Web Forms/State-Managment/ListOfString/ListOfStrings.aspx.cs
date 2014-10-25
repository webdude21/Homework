namespace ListOfString
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class ListOfStrings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.Session.Add("inputState", new List<string>());
            }
            else
            {
                var list = (List<string>)this.Session["inputState"];
                this.ResultLabel.Text = list.Last();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var currentText = this.TextBoxInput.Text;
            var list = (List<string>)this.Session["inputState"];
            list.Add(currentText);
        }
    }
}