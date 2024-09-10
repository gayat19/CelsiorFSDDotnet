using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApp
{
    internal class Employee
    {
        //default constructor   
        public Employee()
        {
           
        }
        //ctrl+.
        //contructor with parameters - parametrized constructor
        public Employee(int id, string name, string designation, double salary, DateTime dateOfBirth, int totalLeave)
        {
            Id = id;
            Name = name;
            Designation = designation;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            TotalLeave = totalLeave;
        }
        public int Id { get; set; }
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
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Designation: {Designation}, Salary: {Salary}, DateOfBirth: {DateOfBirth}, TotalLeave: {TotalLeave}";
        }
    }

}
