using System;

namespace Banking
{
    public class Deposit : Account, IDeposit, IWithdraw
    {
        public Deposit(decimal balance, decimal interestRate, Custumer custumer) : base(balance, interestRate, custumer) { }

        public override decimal CalculateInterest(decimal numberOfMonths)
        {
            if (this.Balance < 1000 && this.Balance >= 0 )
            {
                return 0;
            }

            return base.CalculateInterest(numberOfMonths);
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
                throw new InvalidOperationException("The amount your're trying to withdraw is more than what's in the account.");
            }
        }

        public void DepositMoney(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("You cannot deposit negative amount of money.");
            }
            else
            {
                this.Balance += amount;
            }
        }
    }
}
