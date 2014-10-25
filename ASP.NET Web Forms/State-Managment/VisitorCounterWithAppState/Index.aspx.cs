namespace VisitorCounterWithAppState
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.Web.UI;

    public partial class Index : Page
    {
        private const string VisitorCounter = "visits";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Application[VisitorCounter] == null)
            {
                this.Application.Add(VisitorCounter, 1);
            }
            else
            {
                var currentVisitorCount = (int)this.Application[VisitorCounter];
                this.Application[VisitorCounter] = currentVisitorCount + 1;
            }

            var generatedImage = new Bitmap(300, 50);
            using (generatedImage)
            {
                var gr = Graphics.FromImage(generatedImage);
                using (gr)
                {
                    gr.FillRectangle(Brushes.Blue, 0, 0, 300, 50);

                    gr.DrawString(
                        ("Visits: " + (int)this.Application[VisitorCounter]).ToString(CultureInfo.InvariantCulture), 
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