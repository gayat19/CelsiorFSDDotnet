using System.Runtime.CompilerServices;

namespace UnderstandingDelegateApp
{
    class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public override string ToString()
        {
            return "Id = " + ID + ", Name = " + Name + ", Salary = " + Salary;
        }
    }
    internal class Program
    {
        List<Employee> employees = new List<Employee>()
        {
            new Employee { ID = 101, Name = "Mark", Salary = 5000 },
            new Employee { ID = 102, Name = "John", Salary = 14000 },
            new Employee { ID = 103, Name = "Smith", Salary = 5000 },
            new Employee { ID = 104, Name = "Watson", Salary = 15000 }
        };
        public Program()
        {
            UnderstandingLINQ();
        }
        void UnderstandingLINQ()
        {
            var highPaidEmployees = employees.Where(e => e.Name.Contains("o")).OrderByDescending(emp => emp.Salary).Take(1);

            foreach (var employee in highPaidEmployees)
            {
                Console.WriteLine(employee);
            }
        }
        static void Main(string[] args)
        {
            new Program();
        }
    }
}
