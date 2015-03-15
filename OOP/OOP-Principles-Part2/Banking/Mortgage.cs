namespace Banking
{
    using System;

    public class Mortgage : Account, IDeposit
    {
        private const int FullYearMonths = 12;

        private const int HalfYearMonths = 6;

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
            if (this.Custumer is Individual && numberOfMonths > HalfYearMonths)
            {
                numberOfMonths -= HalfYearMonths;
                return base.CalculateInterest(numberOfMonths);
            }

            if (this.Custumer is Company && numberOfMonths > FullYearMonths)
            {
                numberOfMonths -= FullYearMonths;
                return (base.CalculateInterest(FullYearMonths) / 2) + base.CalculateInterest(numberOfMonths);
            }

            if (this.Custumer is Company)
            {
                return base.CalculateInterest(numberOfMonths) / 2;
            }

            return 0;
        }
    }
}