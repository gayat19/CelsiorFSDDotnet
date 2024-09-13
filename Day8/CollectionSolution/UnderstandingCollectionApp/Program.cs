using System.Collections;

namespace UnderstandingCollectionApp
{
    internal class Program
    {
        void UnderstandingCollection()
        {
            ArrayList numbers = new ArrayList();
            numbers.Add(100);
            numbers.Add(234);
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            numbers.Add(new Random().Next(100, 200));
            numbers.Add("Hello");
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += Convert.ToInt32(numbers[i]);   
            }
            Console.WriteLine(sum);
        }
        void UnderstandingList()
        {
            List<int> numbers = new List<int>();//generic collection - typesafe
            numbers.Add(100);
            //numbers.Add("Hello");//not possible
            for(int i = 0; i < 10; i++)
            {
                numbers.Add(new Random().Next(i, 100));
            }
            numbers.Sort();
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        void UnderstaingMoreOnList()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer(100,"Ramu",1234567890),
                new Customer(101,"Bimu",5544332211),
                new Customer(102,"Domu",9876543210 )
            };
            //int choice = 0;
            //do
            //{
            //    Customer customer = new Customer();
            //    customer.GetCustomerDetaislFromConsole();
            //    customer.Id = customers.Count + 100;
            //    customers.Add(customer);    
            //    Console.WriteLine("Do you want to continue? Then enter any number otehr than 0.");
            //    choice = Convert.ToInt32(Console.ReadLine());
            //} while (choice !=0);
            Console.WriteLine("----------------------------------------");

            //foreach (var customer in customers)
            //{
            //    Console.WriteLine(customer);
            //}   
            //Console.WriteLine(customers[0]);//We can access the elements using index
            //bool isCustomerFound = customers.Contains(new Customer(100, "Ramu", 1234567890));
            //Console.WriteLine("Is Ramu present "+isCustomerFound);
            var index = customers.IndexOf(new Customer(100, "Ramu", 1234567890));
            Console.WriteLine(index);
            //customers.RemoveAt(index);
            //customers.Remove(new Customer(100, "Ramu", 1234567890));
            customers.Sort();
            foreach (var item in customers)
            {
                Console.WriteLine(item);
            }

        }
        void UnderstandingDictionary()
        {
            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
            customers.Add(100, new Customer(100, "Ramu", 1234567890));
            customers.Add(101, new Customer(101, "Bimu", 5544332211));
            customers.Add(101, new Customer(101, "Domu", 9876543210));
            foreach (var item in customers.Keys)
            {
                Console.WriteLine(customers[item]);
            }
        }
            void UnderstaningLimitationOfArray()
        {
            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = i *100+ new Random().Next(10,100);
            }
            //To increase the size of array we have to create a new array and copy the old array to new array
            int[] nums1 = new int[12];
            for (int i = 0; i < 10; i++)
            {
                nums1[i] = numbers[i];
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
           // program.UnderstaningLimitationOfArray();
           //program.UnderstandingCollection();
           //program.UnderstandingList();
          // program.UnderstaingMoreOnList();
                program.UnderstandingDictionary();
        }
    }
}
