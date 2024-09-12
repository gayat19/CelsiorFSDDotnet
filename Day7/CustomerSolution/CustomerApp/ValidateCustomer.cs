using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class ValidateCustomer : IValidateCustomer
    {
        int CalculateAge(DateTime dateOfBirth)
        {
            var diff = DateTime.Now - dateOfBirth;
            var days = diff.Days;
            if (days < 0)
                throw new InvalidDateException();
            return (days / 365);
        }


        private void PrintResult(Customer customer, int age)
        {
            var salutation = customer.Gender == "M" ? "Mr" : "Ms";
            if (age < 18)
            {
                Console.WriteLine($"Dear {salutation}. {customer.Name} you are {age} years old and so not eligible to vote.");
            }
            else
            {
                Console.WriteLine($"Dear {salutation}. {customer.Name} you are {age} years old and so you are eligible to vote.");
            }
        }

        public void ValidateCustomerByAge(Customer customer)
        {
            var age = CalculateAge(customer.DateOfBirth);
            PrintResult(customer, age);
        }
    }
}
