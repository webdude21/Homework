namespace AjaxPhotoAlbum
{
    using System;
    using System.Web.Services;
    using System.Web.UI;

    using AjaxControlToolkit;

    public partial class Gallery : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static Slide[] GetSlides()
        {
            var imgSlide = new Slide[5];

            imgSlide[1] = new Slide("images/1.jpg", "1", string.Empty);
            imgSlide[2] = new Slide("images/2.jpg", "2", string.Empty);
            imgSlide[0] = new Slide("images/3.jpg", "3", string.Empty);
            imgSlide[3] = new Slide("images/4.jpg", "4", string.Empty);
            imgSlide[4] = new Slide("images/5.jpg", "5", string.Empty);

            return imgSlide;
        }
    }
}