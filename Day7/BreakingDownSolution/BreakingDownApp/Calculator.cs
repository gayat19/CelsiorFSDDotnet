using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingDownApp
{
    public class Calculator : ICalculate
    {
        public Numbers NumberProperty { get; set; }
        public Calculator()
        {
            NumberProperty = new Numbers();
        }
        void PrintResult(string opetration,double result)
        {   
            Console.WriteLine($"The result of {opetration} on {NumberProperty} is {result}");
        }
        public void Add()
        {
            NumberProperty.TakeNumbersFromConsole();
            double result = NumberProperty.Number1 + NumberProperty.Number2;
            PrintResult("Addition", result);
        }

        public void Divide()
        {
            NumberProperty.TakeNumbersFromConsole();
            double result = NumberProperty.Number1 / NumberProperty.Number2;
            PrintResult("Division", result);
        }

        public void Multiply()
        {
            NumberProperty.TakeNumbersFromConsole();
            double result = NumberProperty.Number1 * NumberProperty.Number2;
            PrintResult("Multiplication", result);
        }

        public void Subtract()
        {
            NumberProperty.TakeNumbersFromConsole();
            double result = NumberProperty.Number1 - NumberProperty.Number2;
            PrintResult("Subtraction", result);
        }
    }
}
