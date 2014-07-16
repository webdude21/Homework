namespace Banking
{
    using System;

    public class Deposit : Account, IDeposit, IWithdraw
    {
        public Deposit(decimal balance, decimal interestRate, Custumer custumer)
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

        public void DrawMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("You cannot withdraw negative amount of money.");
            }

            if (this.Balance > amount)
            {
                this.Balance -= amount;
            }
            else
            {
                throw new InvalidOperationException(
                    "The amount you're trying to withdraw is more than what's in the account.");
            }
        }

        public override decimal CalculateInterest(decimal numberOfMonths)
        {
            if (this.Balance < 1000 && this.Balance >= 0)
            {
                return 0;
            }

            return base.CalculateInterest(numberOfMonths);
        }
    }
}