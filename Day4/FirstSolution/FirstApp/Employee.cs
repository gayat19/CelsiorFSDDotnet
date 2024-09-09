using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp
{
    internal class Employee
    {
        //public int Id;// Not Object Oriented
        public Employee() 
        {
            Id = 101;
            Name = "Ramu";
            Designation = "Developer";
            Salary = 10000;
            DateOfBirth = new DateTime(2000, 9, 7);
            TotalLeave = 10;
        }
        public int Id { get; set; }
        //A short version of the bellow code
        //int id;
        //public int GetId()
        //{
        //    return id;
        //}
        //public void SetId(int value)
        //{
        //    id = value;
        //}
        public string Name { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TotalLeave { get; set; }
        public void DoWork()
        {
            Console.WriteLine("Employee does his work");
        }
        private double num1;//private member
        public void TakeLeave()
        {
            num1 = 10;//Can access privete member inside the same class
            if (TotalLeave > 0)
            {
                TotalLeave--;
                Console.WriteLine($"{Name} takes leave. Remaining leave - {TotalLeave}");
            }
            else
            {
                Console.WriteLine($"{Name} has no leave balance");
            }
        }
    }
}
