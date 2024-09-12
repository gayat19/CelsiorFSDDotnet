using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

        public virtual bool TakeCustomerDetailsFromConsole()
        {
            Console.WriteLine("Enter the customer id:");
            Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the customer name:");
            Name = Console.ReadLine() ?? "";
            Console.WriteLine("Enter the customer date of birth:");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the gender(M/F");
            Gender = Console.ReadLine() ?? "F";
            return true;

        }
    }
}
