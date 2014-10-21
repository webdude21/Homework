namespace Calculator
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public partial class Calculator : Page
    {
        private const string DefaultValue = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.ViewState["currentValue"] = DefaultValue;
            }
        }

        protected void ButtonOperation_Click(object sender, EventArgs e)
        {
            var currentOperation = ((Button)sender).Text;
            var firstOpperand = decimal.Parse(this.TextBoxResult.Text);
            var result = DefaultValue;

            if (currentOperation == "√")
            {
                result = firstOpperand < 0 ? "Invalid input!" : Math.Sqrt((double)firstOpperand).ToString();
            }
            else
            {
                this.ViewState["firstOpperand"] = firstOpperand;
                this.ViewState["currentValue"] = DefaultValue;
                this.ViewState["operation"] = ((Button)sender).Text;
            }

            this.TextBoxResult.Text = result;
        }

        protected void ButtonDigit_Click(object sender, EventArgs e)
        {
            var digit = ((Button)sender).Text;
            var currentCalcValue = this.ViewState["currentValue"] as string;

            if (currentCalcValue == DefaultValue)
            {
                currentCalcValue = digit;
            }
            else
            {
                currentCalcValue += digit;
            }

            this.ViewState["currentValue"] = currentCalcValue;
            this.TextBoxResult.Text = (string)this.ViewState["currentValue"];
        }

        protected void ButtonEquals_Click(object sender, EventArgs e)
        {
            var secondOperrand = decimal.Parse(this.TextBoxResult.Text);
            var firstOpperand = (decimal)this.ViewState["firstOpperand"];
            this.TextBoxResult.Text = DefaultValue;
            var result = DefaultValue;
            var currentOperation = (string)this.ViewState["operation"];

            switch (currentOperation)
            {
                case "+":
                    result = (firstOpperand + secondOperrand).ToString();
                    break;
                case "-":
                    result = (firstOpperand - secondOperrand).ToString();
                    break;
                case "x":
                    result = (firstOpperand * secondOperrand).ToString();
                    break;
                case "/":
                    {
                        if (firstOpperand == 0m)
                        {
                            result = DefaultValue;
                            break;
                        }

                        if (secondOperrand != 0m)
                        {
                            result = (firstOpperand / secondOperrand).ToString();
                        }
                        else
                        {
                            result = "Cannot divide by zero!";
                        }
                    }

                    break;
            }

            this.TextBoxResult.Text = result;
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            this.ViewState.Clear();
            this.TextBoxResult.Text = DefaultValue;
        }
    }
}