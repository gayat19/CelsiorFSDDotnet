using System;

namespace FirstApp
{
    internal class Program
    {
        //int Take1NumberInputFromConsole()
        //{
        //    int num1;
        //    Console.WriteLine("Please enter the number");
        //    num1 = Convert.ToInt32(Console.ReadLine());
        //    return num1;
        //}
        //void Add2Numbers(int num1,int num2)
        //{
        //    int sum = num1 + num2;
        //    Console.WriteLine("The sum of "+num1+" and "+num2+" is "+sum);//Concatenation
        //    Console.WriteLine($"The sum of {num1} and {num2} is {sum}");//interpollation
        //}
        //void Product2Numbers(int num1, int num2)
        //{
        //    int product = num1 * num2;
        //    Console.WriteLine($"The product of {num1} and {num2} is {product}");
        //}
        ////To print the biggest of 2
        //void BiggestOf2(int num1, int num2)
        //{
        //    if (num1 == num2)
        //    {
        //        Console.WriteLine($"{num1} is equal to {num2}");
        //    }
        //    else if (num1 > num2)
        //    {
        //        Console.WriteLine($"{num1} is bigger than {num2}");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"{num2} is bigger than {num1}");
        //    }

        //}
        //void Calculate()
        //{
        //    int number1 = Take1NumberInputFromConsole();
        //    int number2 = Take1NumberInputFromConsole();
        //    Add2Numbers(number1, number2);
        //    Product2Numbers(number1, number2);
        //}
        void ManageEmployee()
        {
            //Create an object of Employee
            Employee employee = new Employee();//new will allocate memory, Then we can see the call for constructor
            
            Console.WriteLine("Employee needs leave - 1");
            employee.TakeLeave();
            Console.WriteLine("Employee needs one more leave - 2");
            employee.TakeLeave();
            Console.WriteLine("Employee needs one more leave - 3");
            employee.TakeLeave();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Calculate();
            program.ManageEmployee();

        }
    }
}
