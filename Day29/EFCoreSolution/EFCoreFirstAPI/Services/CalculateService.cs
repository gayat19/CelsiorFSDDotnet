using EFCoreFirstAPI.Interfaces;

namespace EFCoreFirstAPI.Services
{
    public class CalculateService : ICalculate
    {
        public int Add(int num1, int num2)
        {
            return num1 + num2;
        }

        public int Multiply(int num1, int num2)
        {
           return num1 * num2;
        }
    }
}
