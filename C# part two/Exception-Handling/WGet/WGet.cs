namespace WGet
{
    using System;
    using System.Net;

    internal class Program
    {
        private static void Main()
        {
            using (var wc = new WebClient())
            {
                try
                {
                    wc.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
                }
                catch (WebException)
                {
                    Console.WriteLine("The url is invalid.");
                }
                catch (Exception se)
                {
                    Console.WriteLine(se.Message);
                }
            }
        }
    }
}