using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DumpEvents
{
    public partial class Index : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            Response.Write("On Init happened" + "<br/>");
            base.OnInit(e);
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Response.Write("Page_PreInit happened" + "<br/>");
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            Response.Write("Page_Init happened" + "<br/>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Page_Load happened" + "<br/>");
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Write("Page_PreRender happened" + "<br/>");
        }


        protected void ButtonOK_Init(object sender, EventArgs e)
        {
            Response.Write("ButtonOK_Init happened" + "<br/>");
        }

        protected void ButtonOK_Load(object happened, EventArgs e)
        {
            Response.Write("ButtonOK_Load invoked" + "<br/>");
        }

        protected void ButtonOK_Click(object happened, EventArgs e)
        {
            Response.Write("ButtonOK_Click invoked" + "<br/>");
        }

        protected void ButtonOK_PreRender(object happened, EventArgs e)
        {
            Response.Write("ButtonOK_PreRender invoked" + "<br/>");
        }

    }
}