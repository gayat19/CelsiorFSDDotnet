using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public  class PremiumCustomer   : Customer
    {
        public string Membership { get; set; }
        public PremiumCustomer()
        {
            Membership = "Gold";
        }
        public override bool TakeCustomerDetailsFromConsole()
        {
            try
            {
                base.TakeCustomerDetailsFromConsole();//call the base calss method
                Console.WriteLine("Enter the membership type:");
                Membership = Console.ReadLine() ?? "Gold";
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidInputDetailException();
            }
        }
    }
}
