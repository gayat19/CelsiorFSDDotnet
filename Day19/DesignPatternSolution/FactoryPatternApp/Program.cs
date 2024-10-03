namespace FactoryPatternApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank icici = new Bank();
            icici.CustomerInteraction();
            icici.PrintAccounts();
        }
    }
}
