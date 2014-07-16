namespace Banking
{
    using System;

    public class Mortgage : Account, IDeposit
    {
        public Mortgage(decimal balance, decimal interestRate, Custumer custumer)
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
            if (this.Custumer is Individual && numberOfMonths > 6)
            {
                numberOfMonths -= 6;
                return base.CalculateInterest(numberOfMonths);
            }

            if (this.Custumer is Company && numberOfMonths > 12)
            {
                numberOfMonths -= 12;
                return (base.CalculateInterest(12) / 2) + base.CalculateInterest(numberOfMonths);
            }

            if (this.Custumer is Company)
            {
                return base.CalculateInterest(numberOfMonths) / 2;
            }

            return 0;
        }
    }
}