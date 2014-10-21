using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SimpleHello
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonShowHello_Click(object sender, EventArgs e)
        {
            var name = TextBoxName.Text;
            ResultLabel.Text = "Hello " + name;
        }
    }
}