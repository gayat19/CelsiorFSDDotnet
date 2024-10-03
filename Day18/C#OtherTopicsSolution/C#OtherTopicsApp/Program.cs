namespace C_OtherTopicsApp
{
    internal class Program
    {
        void TestEmployee()
        {
            //Employee employee = new Employee();
            //employee = null;
            //GC.Collect();
            using(Employee employee = new Employee())
            {
                Console.WriteLine(employee.Name);
                employee[0] = "C-Sharp";    
                Console.WriteLine(employee[0]);
                Console.WriteLine("The position of MVC in the skills is " + employee["MVC"]);
                if(employee.AvailSickLeave(5))
                    Console.WriteLine("Leave approved");
                else
                    Console.WriteLine("Leave declined");
            }
        }
        void HandleProduct()
        {
            Product product1 = new Product() { Id = 101, Name = "Laptop", Price = 50000 };
            Product product2 = new Product() { Id = 102, Name = "Mobile", Price = 20000 };
            Product product =  product1 + product2;
            Console.WriteLine(product);

        }

        void HandlingPrivateConstructor()
        {
            Connection connection1 = Connection.GetConnection();
            connection1.ConnectionName = "MyConnection - one";
            Console.WriteLine(connection1.ConnectionName);
            //nonew object will be created
            Connection connection2 = Connection.GetConnection();//the same object will be given
            connection2.ConnectionName = "MyConnection - two";
            Console.WriteLine(connection2.ConnectionName);
            Console.WriteLine("Print from teh first reference");
            Console.WriteLine(connection1.ConnectionName);
        }
        void HandleStaticMemberOfClass()
        {
            Console.WriteLine(Company.NumberOfEmployees);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.HandleStaticMemberOfClass();
        }
    }
}
