using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrintFromCodeBehind
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var html = "<h2>Hello, from отзад:)</h2>";

            byte[] bytes = Encoding.UTF8.GetBytes(html);

            Context.Response.OutputStream.Write(bytes, 0, bytes.Length);

            var asm = Assembly.GetExecutingAssembly();

            var info = string.Format("{0} <br/> {1}", asm.FullName, asm.Location);

            codeInfo.InnerHtml = info;
        }
    }
}