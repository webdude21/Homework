namespace ATMTransactions
{
    using System;
    using System.Linq;
    using System.Transactions;

    using ATM.Data;
    using ATM.Model;

    public class AtmTransaction
    {
        private readonly AtmDbContext databesContext;

        public AtmTransaction(AtmDbContext databesContext)
        {
            this.databesContext = databesContext;
        }

        public AtmTransaction()
            : this(new AtmDbContext())
        {
        }

        public void Widthdraw(decimal amount, string cardNumber, string pin)
        {
            using (var transaction = new TransactionScope())
            {
                this.CheckIfCardNumerIsValid(cardNumber);
                this.CheckIfPinIsValid(cardNumber, pin);
                this.CheckIfSufficiantAmountExists(amount, cardNumber);
                this.BalanceTheAccount(amount, cardNumber);
                this.LogTransaction(amount, cardNumber);
                transaction.Complete();
            }

            this.databesContext.SaveChanges();
        }

        private void LogTransaction(decimal amount, string cardNumber)
        {
            this.databesContext.TransactionsHistories.Add(
                new TransactionsHistory { Amount = amount, CardNumber = cardNumber, TransactionDate = DateTime.Now });
        }

        private void BalanceTheAccount(decimal amount, string cardNumber)
        {
            var cardAccount = this.databesContext.CardAccounts.First(card => card.CardNumber.Equals(cardNumber));
            cardAccount.CardCash -= amount;
        }

        private void CheckIfSufficiantAmountExists(decimal amount, string cardNumber)
        {
            var cardAccount = this.databesContext.CardAccounts.First(card => card.CardNumber.Equals(cardNumber));
            if (cardAccount.CardCash < amount)
            {
                throw new ArgumentException("The amount of money in the account is not sufficient!");
            }
        }

        private void CheckIfCardNumerIsValid(string cardNumber)
        {
            var foundValidCardNumber = this.databesContext.CardAccounts.Any(card => card.CardNumber.Equals(cardNumber));

            if (!foundValidCardNumber)
            {
                throw new ArgumentException("The card number is not valid!");
            }
        }

        private void CheckIfPinIsValid(string cardNumber, string pin)
        {
            var cardAccount = this.databesContext.CardAccounts.First(card => card.CardNumber.Equals(cardNumber));

            if (!cardAccount.CardPin.Equals(pin))
            {
                throw new ArgumentException("The pin used with this card number is incorrect!");
            }
        }
    }
}