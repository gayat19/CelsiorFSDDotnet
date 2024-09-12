using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreakingDownApp
{
    public class Numbers
    {
        public double Number1 { get; set; }
        public double Number2 { get; set; }

        public void TakeNumbersFromConsole()
        {
            Console.WriteLine("Please enter the first number");
            Number1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the second number");
            Number2 = Convert.ToDouble(Console.ReadLine());
        }

        public override string ToString()
        {
            return $"Number1: {Number1}, Number2: {Number2}";
        }

    }
}
