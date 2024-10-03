using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal class CurrentAccount : Account
    {
        public CurrentAccount(double balance, long accountNumber) : base("Current", balance, accountNumber)
        {
        }

        public override void Deposit(double amount)
        {
            if(amount<5000)
            {
                Balance += amount;
                Console.WriteLine("Amount deposit success.");
                PrintStatement();
            }
            else if(amount > 5000)
            {
                Balance = Balance + amount - 100;
                Console.WriteLine("Amount deposit success. Rs. 100 deducted for cash deposit");
            }
            else
                Console.WriteLine("Invalid amount. Deposit failed");
        }

        public override void Withdraw(double amount)
        {
            if (amount < Balance)
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
