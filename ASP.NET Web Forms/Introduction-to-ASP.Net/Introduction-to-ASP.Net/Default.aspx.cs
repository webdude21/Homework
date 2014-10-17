using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Introduction_to_ASP.Net
{
    public partial class _Default : Page
    {
        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            string sum;

            try
            {
                var firstNumber = decimal.Parse(TextBoxFirstNumber.Text);
                var secondNumber = decimal.Parse(TextBoxSecondNumber.Text);
                sum = (firstNumber + secondNumber).ToString();
            }
            catch (FormatException)
            {
                sum = "Cannot parse the numbers";
            }

            TextBoxResult.Text = sum;
        }
    }
}