using System.Collections.Generic;
using System.Linq;

namespace Banking
{
    public class Bank
    {
        public string Name { get; private set; }
        private List<Account> bankAccounts = new List<Account>();

        public List<Account> BankAccounts
        {
            get { return new List<Account>(this.bankAccounts); }
        }

        public Bank(string name)
        {
            this.Name = name;
        }

        public void AddAccounts(IEnumerable<Account> accounts)
        {
            this.bankAccounts.AddRange(accounts);
        }

        public void RemoveAccounts(IEnumerable<Account> accounts)
        {
            foreach (Account account in accounts)
            {
                this.bankAccounts.Remove(account);
            }
        }

        public void RemoveAllAccounts()
        {
            this.bankAccounts.Clear();
        }

        public override string ToString()
        {
            return this.Name + "holds the following: \r\n" + string.Join("\r\n", this.bankAccounts);
        }

        public decimal AvarageInterestRate(decimal monthsOfInterest)
        {
            return this.bankAccounts.Average(account => account.CalculateInterest(monthsOfInterest));
        }
    }
}
