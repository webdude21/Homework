namespace Banking
{
    public abstract class Account
    {
        protected Account(decimal balance, decimal interestRate, Custumer custumer)
        {
            this.Balance = balance;
            this.InterestRate = interestRate;
            this.Custumer = custumer;
        }

        public decimal Balance { get; protected set; }

        public decimal InterestRate { get; protected set; }

        public Custumer Custumer { get; protected set; }

        public virtual decimal CalculateInterest(decimal numberOfMonths)
        {
            return numberOfMonths * this.InterestRate;
        }

        public override string ToString()
        {
            return
                string.Format(
                    "This is a {0} account, it belongs to the {1} '{2}'. It has a balance of {3} and an interst rate of {4}", 
                    this.GetType().Name.ToLower(), 
                    this.Custumer.GetType().Name.ToLower(), 
                    this.Custumer.Name, 
                    this.Balance, 
                    this.InterestRate);
        }
    }
}