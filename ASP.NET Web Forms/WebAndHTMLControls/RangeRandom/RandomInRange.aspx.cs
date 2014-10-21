namespace RangeRandom
{
    using System;
    using System.Web.UI;

    public partial class RandomInRange : Page
    {
        private static Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonClick(object sender, EventArgs e)
        {
            try
            {
                var firstNum = int.Parse(this.firstNumber.Value);
                var secondNum = int.Parse(this.secondNumber.Value);
                int swap;

                if (firstNum > secondNum)
                {
                    swap = firstNum;
                    firstNum = secondNum;
                    secondNum = swap;
                }

                var randomNumber = random.Next(firstNum, secondNum);
                this.result.InnerText = randomNumber.ToString();
            }
            catch (FormatException)
            {
                this.result.InnerText = "Please use only integers!";
            }
        }
    }
}