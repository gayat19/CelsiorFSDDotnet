using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingCollectionApp
{
    public class Customer : IEquatable<Customer>, IComparable<Customer>
    {
        public Customer()
        {
            
        }
        public Customer(int id, string name, long phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
        }
        public void GetCustomerDetaislFromConsole()
        {
            Console.WriteLine("Enter the customer name");
            Name = Console.ReadLine()??"";
            Console.WriteLine("Enter the customer phone");
            Phone = Convert.ToInt64(Console.ReadLine());
        }
        public int Id { get; set; }
        public string Name{ get; set; } = string.Empty;
        public long Phone { get; set; }
        public override string ToString()
        {
            return "Id: " + Id + " Name: " + Name + " Phone: " + Phone;
        }

        public bool Equals(Customer? other)
        {
            Customer c1, c2;
            c1 = this;
            c2 = other;
            if (c1.Id == c2.Id && c1.Name == c2.Name && c1.Phone == c2.Phone)
            {
                return true;
            }
            return false;
        }

        public int CompareTo(Customer? other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
