using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal class Bank
    {
        List<Account> accounts = new List<Account>();
        IAccountFactory accountFactory = new AccountFactory();

        void AddAccount(string accountType,  long accountNumber)
        {
            Account account = accountFactory.CreateAccount(accountType,  accountNumber);
            accounts.Add(account);
        }
        public void CustomerInteraction()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Enter the account type you wish to create");
                string accountType = Console.ReadLine() ?? "Savings";
                long accountNumber = 0;
                if(accounts.Count > 0)
                    accountNumber = accounts.Max(a => a.AccountNumber) + 1;
                else
                    accountNumber = 10001;
                AddAccount(accountType, accountNumber ); // 0 and 0 are dummy values
                Console.WriteLine("Do you want to add another account. enter 0 to stop. Any number to continue adding");
                choice = Convert.ToInt32(Console.ReadLine());

            } while (choice != 0);

        }

        internal void PrintAccounts()
        {
            foreach (var account in accounts)
            {
                account.PrintStatement();
                Console.WriteLine("*********************************");
            }
        }
    }
}
