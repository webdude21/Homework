namespace RegisterValidation
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
        }

        protected void CheckBoxRequired_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = this.CheckBoxAccepted.Checked;
        }
    }
}