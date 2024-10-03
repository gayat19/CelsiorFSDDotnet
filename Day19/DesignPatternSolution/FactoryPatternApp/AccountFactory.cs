using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal class AccountFactory : IAccountFactory
    {
        public Account CreateAccount(string accountType,  long accountNumber)
        {
            if (accountType == "Current")
                return new CurrentAccount(10000, accountNumber);
            else if (accountType == "Savings")
                return new SavingsAccount(5000, accountNumber);
            else
                throw new Exception("Invalid account type");
        }
    }
}
