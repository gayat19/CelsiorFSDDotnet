using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(double balance, long accountNumber) : base("Savings", balance, accountNumber)
        {
        }

        public override void Deposit(double amount)
        {
            if (amount >0)
            {
                Balance += amount;
                Console.WriteLine("Amount deposit success.");
                PrintStatement();
            }
            else
                Console.WriteLine("Invalid amount. Deposit failed");
        }

        public override void Withdraw(double amount)
        {
            if ((Balance-amount) > 5000)
            {
                Balance -= amount;
                Console.WriteLine("Amount withdrawn successfully.");
                PrintStatement();
            }
            else
                Console.WriteLine("Insufficient balance. Withdrawal failed.");
        }
    }
}
