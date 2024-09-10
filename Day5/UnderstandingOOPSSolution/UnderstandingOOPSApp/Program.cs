namespace UnderstandingOOPSApp
{
    internal class Program
    {

        //create employee object by getting data from user in console and retuyrn back teh object
        Employee CreateEmployee()
        {
            var employee = new Employee();
            Console.WriteLine("Please enter the employee Id");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee Name");
            employee.Name = Console.ReadLine()??"";
            Console.WriteLine("Please enter the employee Designation");
            employee.Designation = Console.ReadLine()??"";
            Console.WriteLine("Please enter the employee Salary");
            employee.Salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the employee Date of Birth");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please enter the employee Total Leave");
            employee.TotalLeave = Convert.ToInt32(Console.ReadLine());
            return employee;
        }
        static void Main(string[] args)
        {
               var program = new Program();
            //Employee employee1 = new Employee(101, "John", "Manager", 50000, new DateTime(1980, 1, 1), 10);
            ////Employee employee2 = new Program().CreateEmployee();//anonymous object does not have any reference
            //Employee employee2 = new Employee(102, "Smith", "Developer", 40000, new DateTime(1985, 1, 1), 12);
            ////the program class object does not have any valid reference
            //Issue issue1 = new Issue(1, "Chair Unavailable", "The working chair is not available in the floor", 102);
            //issue1.AssignIssue(101);
            //issue1.ChangeStatus("Closed");
            //Console.WriteLine(issue1);
            //-------------------------------------
            //Undertanding Inhertance
            //Bike obj = new MotorBike();
            //obj.PrintName();
            //int[] numbers =new int[7] { 66,89,90,77,54,92,80 };
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine(numbers[i]);
            //}
            Employee[] employees = new Employee[2];
            for (int i = 0; i < employees.Length; i++)
            {
                employees[i] = program.CreateEmployee();
            }
            for (int i = 0; i < employees.Length; i++)
            {
                Console.WriteLine(employees[i]);
            }

        }
    }
    
    //class Bike
    //{
    //    protected string Name { get; set; } = string.Empty;
    //    public Bike()
    //    {
    //        Console.WriteLine("parent constructed");
    //        Name = "Ramu";
    //    }
    //    public virtual void PrintName()//If my child class chooses to provide new functionality, it can override the method
    //    {
    //        Console.WriteLine("Parent "+Name);
    //    }
    //}
    //class MotorBike : Bike
    //{
    //    public MotorBike()
    //    {
    //        Console.WriteLine("Chlid constructed");
    //        Name += " Somu";
    //    }
    //    public override void PrintName()//Changing the parent functionality
    //    {
    //        Console.WriteLine("Child "+Name);
    //    }
    //}
}
