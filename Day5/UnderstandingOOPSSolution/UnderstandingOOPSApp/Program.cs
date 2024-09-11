namespace UnderstandingOOPSApp
{
    internal class Program
    {
        IEmployeeService employeeService;
        public Program()
        {
            employeeService = new EmployeeService();
           
        }
        //create employee object by getting data from user in console and retuyrn back teh object
        void PrintMenu()
        {
            Console.WriteLine("Welcome to the Issue Managment Service");
            Console.WriteLine("1 - Raise Issue");
            Console.WriteLine("2 - Close Issue");
            Console.WriteLine("3 - View All Issues");
            Console.WriteLine("0 - Exit");
        }
        void EmployeeInteraction()
        {
            var choice = 0;
            do
            {
                PrintMenu();
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        RaiseIssue();
                        break;
                    case 2:
                        CloseIssue();
                        break;
                    case 3:
                        PrintAllIssuesByEmployee();
                        break;
                    default:
                        Console.WriteLine("Ïnvalid option");
                        break;
                }
            }while(choice != 0);
        }

        private void PrintAllIssuesByEmployee()
        {
            Console.WriteLine("Please enter your employee Id");
            var eid = Convert.ToInt32(Console.ReadLine());
            var issues = employeeService.GetAllIssues(eid);
            if(issues != null && issues.Length > 0)
            {
                foreach (var issue in issues)
                {
                    Console.WriteLine(issue);
                }
            }
            else
            {
                Console.WriteLine("No issues found for the employee");
            }
        }

        private void CloseIssue()
        {
           Issue issue = new Issue();
            Console.WriteLine("Enter Issue ID");
            issue.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Employee ID");
            issue.ReportedBy = Convert.ToInt32(Console.ReadLine());
            employeeService.CloseIssue(issue.ReportedBy, issue);
            
        }

        private void RaiseIssue()
        {
            Issue issue = new Issue();
            Console.WriteLine("Enter Issue Title");
            issue.Title = Console.ReadLine();
            Console.WriteLine("Enter Issue Description");
            issue.Description = Console.ReadLine();
            Console.WriteLine("Enter your Employee ID");
            issue.ReportedBy = Convert.ToInt32(Console.ReadLine());
            employeeService.RaiseIssue(issue.ReportedBy, issue);
        }

        static void Main(string[] args)
        {
               var program = new Program();
                program.EmployeeInteraction();
        }
    }
}
