namespace RangeRandomWithWebControls
{
    using System;
    using System.Web.UI;

    public partial class Range : Page
    {
        private static Random random = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void getRandom_Click(object sender, EventArgs e)
        {
            try
            {
                var firstNum = int.Parse(this.fistNumber.Text);
                var secondNum = int.Parse(this.secondNumber.Text);
                int swap;

                if (firstNum > secondNum)
                {
                    swap = firstNum;
                    firstNum = secondNum;
                    secondNum = swap;
                }

                var randomNumber = random.Next(firstNum, secondNum);
                this.LabelResult.Text = randomNumber.ToString();
            }
            catch (FormatException)
            {
                this.LabelResult.Text = "Please use only integers!";
            }
        }
    }
}