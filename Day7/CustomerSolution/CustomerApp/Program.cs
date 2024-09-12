namespace CustomerApp
{
    internal class Program
    {
        Customer customer;
        IValidateCustomer validateCustomer;
        public Program()
        {
            customer = new PremiumCustomer();
            validateCustomer = new ValidateCustomer();
        }
        void CheckCustomer()
        {
            try
            {
                customer.TakeCustomerDetailsFromConsole();
                validateCustomer.ValidateCustomerByAge(customer);
            }
            catch (InvalidInputDetailException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(InvalidDateException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            new Program().CheckCustomer();

        }
    }
}
