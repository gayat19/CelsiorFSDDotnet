using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal abstract class Account
    {
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public long AccountNumber { get; set; }

        public Account(string accountType, double balance, long accountNumber)
        {
            AccountType = accountType;
            Balance = balance;
            AccountNumber = accountNumber;
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Account Number: {AccountNumber}");
            Console.WriteLine($"Account Type: {AccountType}");
            Console.WriteLine($"Balance: {Balance}");
        }

        public abstract void Deposit(double amount);
        public abstract void Withdraw(double amount);
    }
}
