namespace VisitorsFromDb
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Web.UI;

    using Visitors.Data;

    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var counterContext = new CounterContext();
            counterContext.Visitors.Add(new Visitor());
            counterContext.SaveChanges();
            var currentCount = counterContext.Visitors.Count();

            var generatedImage = new Bitmap(300, 50);
            using (generatedImage)
            {
                var gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.Blue, 0, 0, 300, 50);

                    gr.DrawString(
                        "Visits: " + currentCount, 
                        new Font("Segoe UI", 28), 
                        new SolidBrush(Color.WhiteSmoke), 
                        new PointF(10, 0));

                    this.Response.ContentType = "image/jpeg";

                    generatedImage.Save(this.Response.OutputStream, ImageFormat.Jpeg);
                }
            }
        }
    }
}