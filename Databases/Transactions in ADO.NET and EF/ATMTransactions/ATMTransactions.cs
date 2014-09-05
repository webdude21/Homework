namespace ATMTransactions
{
    using System;
    using System.Linq;

    using ATM.Data;

    internal class AtmTransactions
    {
        private static void Main()
        {
            var databaseContext = new AtmDbContext();
            databaseContext.CardAccounts.Count();

            var atmTransaction = new AtmTransaction(databaseContext);

            TryTransaction(atmTransaction, 200, "1232124124", "2345");
            TryTransaction(atmTransaction, 200, "1232424124", "2345");
            TryTransaction(atmTransaction, 200, "1232124124", "2325");
            TryTransaction(atmTransaction, 200, "2133142112", "1234");
        }

        private static void TryTransaction(AtmTransaction atmTransaction, int amount, string cardNumber, string pin)
        {
            Console.WriteLine("Transaction started");
            try
            {
                atmTransaction.Widthdraw(amount, cardNumber, pin);
                Console.WriteLine("The transaction was successfully completed!");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine("The transaction was rolled back!");
            }
            finally
            {
                Console.WriteLine("-------------------------------------");
            }

        }

    }
}