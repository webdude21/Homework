namespace Banking
{
    using System;

    public class Loan : Account, IDeposit
    {
        public Loan(decimal balance, decimal interestRate, Custumer custumer)
            : base(balance, interestRate, custumer)
        {
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("You cannot deposit negative amount of money.");
            }

            this.Balance += amount;
        }

        public override decimal CalculateInterest(decimal numberOfMonths)
        {
            if (this.Custumer is Individual)
            {
                numberOfMonths -= 3;
            }
            else if (this.Custumer is Company)
            {
                numberOfMonths -= 2;
            }

            if (numberOfMonths > 0)
            {
                return base.CalculateInterest(numberOfMonths);
            }

            return 0;
        }
    }
}