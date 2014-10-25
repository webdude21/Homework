namespace DeleteViewStateFromClient
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.ViewState["values"] == null)
            {
                this.ViewState.Add("values", new List<string>());
            }
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            var list = (List<string>)this.ViewState["values"];
            list.Add(this.TextBox.Text);
            this.Label.Text = string.Empty;
            foreach (var item in list)
            {
                this.Label.Text += "<br/>" + item;
            }

            this.TextBox.Text = string.Empty;
        }
    }
}