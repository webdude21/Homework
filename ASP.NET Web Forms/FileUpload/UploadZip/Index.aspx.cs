namespace UploadZip
{
    using System;
    using System.Text;
    using System.Web.UI;

    using UploadZip.Models;

    public partial class Index : Page
    {
        protected string FileOutput { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var db = new FileUploadContext();

            var sb = new StringBuilder();
            foreach (var item in db.Files)
            {
                sb.AppendFormat("{0}. <br/>", item.Id);
                sb.AppendFormat("{0} <br/>", item.Content);
            }

            this.FileOutput = sb.ToString();
        }
    }
}