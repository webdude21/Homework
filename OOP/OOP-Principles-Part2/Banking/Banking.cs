/* A bank holds different types of accounts for its customers: deposit accounts, 
 * loan accounts and mortgage accounts. Customers could be individuals or companies. 
 * All accounts have customer, balance and interest rate (monthly based). 
 * Deposit accounts are allowed to deposit and with draw money. 
 * Loan and mortgage accounts can only deposit money. All accounts can calculate 
 * their interest amount for a given period (in months). In the common case its is 
 * calculated as follows: number_of_months * interest_rate. Loan accounts have no 
 * interest for the first 3 months if are held by individuals and for the first 2 
 * months if are held by a company. Deposit accounts have no interest if their balance 
 * is positive and less than 1000. Mortgage accounts have ½ interest for the first 12 
 * months for companies and no interest for the first 6 months for individuals. 
 * Your task is to write a program to model the bank system by classes and interfaces.
 * You should identify the classes, interfaces, base classes and abstract actions and
 * implement the calculation of the interest functionality through overridden methods. */

using System;

namespace Banking
{
    class Banking
    {
        static void Main()
        {
            decimal monthsOfInterest = 20;
            Bank obb = new Bank("United Bank of Bulgaria");
            Individual dimo = new Individual("Dimo Petrov");
            Individual petar = new Individual("Petar Georgiev");
            Individual georgi = new Individual("Georgi Gankov");
            Company divastoreEOOD = new Company("DivaStore EOOD");
            Company petkoET = new Company("Petko Jordanov ET");

            Account[] someAccounts = new Account[]
            {
                new Loan(2400, 2, petar),
                new Deposit(10000, 6, divastoreEOOD),
                new Loan(200, 5, divastoreEOOD),
                new Mortgage(60000, 5, georgi),
                new Deposit(1200, 6, georgi),
                new Mortgage(1200000, 3, petkoET),
                new Deposit(800, 7, dimo),
                new Loan(200, 4, dimo )
            };

            obb.AddAccounts(someAccounts);

            //this prints information about all of the accounts in the bank
            Console.WriteLine(obb);
            // this prints the avarage interest for all of the accounts in the collection of accounts
            Console.WriteLine("The average interest for {0} months is {1}", monthsOfInterest, obb.AvarageInterestRate(monthsOfInterest));            
        }
    }
}
