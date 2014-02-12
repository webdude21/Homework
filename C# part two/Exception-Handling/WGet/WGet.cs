using System;
using System.Net;

class Program
{
    static void Main()
    {
        using (WebClient wc = new WebClient())
        {
            try
            {
                wc.DownloadFile("http://www.devbg.org/img/Logo-BASD.jpg", "../../logo.jpg");
            }

            catch (WebException)
            {
                Console.WriteLine("The url is invalid.");
            }

            catch (System.Exception se)
            {
                Console.WriteLine(se.Message);
            }
        }
    }
}