namespace BreakingDownApp
{
    internal class Program
    {
        ICalculate _calculator;
        public Program()
        {
            _calculator = new Calculator();
        }
        void PrintMenu()
        {
            Console.WriteLine("Welcome to the Calculator Application");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.WriteLine("5. Exit");
        }
        void CalculatorOperation()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        _calculator.Add();
                        break;
                    case 2:
                        _calculator.Subtract();
                        break;
                    case 3:
                        _calculator.Multiply();
                        break;
                    case 4:
                        _calculator.Divide();
                        break;
                    case 5:
                        Console.WriteLine("Exiting the application");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            } while(choice != 5);
        }
        static void Main(string[] args)
        {
           new Program().CalculatorOperation();
        }
    }
}
