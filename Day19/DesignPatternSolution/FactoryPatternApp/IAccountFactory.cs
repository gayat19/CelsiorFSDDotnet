using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternApp
{
    internal interface IAccountFactory
    {
        public Account CreateAccount(string accountType, long accountNumber);
    }
}
