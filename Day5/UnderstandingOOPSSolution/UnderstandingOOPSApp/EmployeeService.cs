using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApp
{
    internal class EmployeeService : IEmployeeService, ISolverService
    {
        Employee[] employees;
        Issue[] issues;
        static int count = 0;
        public EmployeeService()
        {
            employees = new Employee[3]
            {
                new Employee{Id=1, Name="John", Designation="Manager", Salary=100000, DateOfBirth=DateTime.Now.AddYears(-30), TotalLeave=5},
                new Employee{Id=2, Name="Smith", Designation="Developer", Salary=70000, DateOfBirth=DateTime.Now.AddYears(-25), TotalLeave=5},
                new Employee{Id=3, Name="Peter", Designation="Tester", Salary=60000, DateOfBirth=DateTime.Now.AddYears(-28), TotalLeave=5}
            };
            issues = new Issue[10];

        }
        public bool CloseIssue(int eid, Issue issue)
        {
            Employee employee = GetEmployee(eid);
            if (employee == null)
            {
                Console.WriteLine("Employee not found");
                return false;
            }
            Issue myIssue = GetIssueById(issue.Id);
            if (myIssue == null)
            {
                Console.WriteLine("Issue not found");
                return false;
            }
            return myIssue.ChangeStatus("Closed");
        }
        private Issue GetIssueById(int issueId)
        {
            Issue issue = null;
            for (var i = 0; i < issues.Length; i++)
            {
                if (issues[i].Id == issueId)
                {
                    issue = issues[i];
                    break;
                }
            }
            return issue;
        }
        private Employee GetEmployee(int eid)
        {
            Employee employee = null;
            for (var i = 0; i < employees.Length; i++)
            {
                if (employees[i].Id == eid)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        public Issue[] GetAllIssues(int eid)
        {
           var raisedissues = new Issue[count];
            Employee employee = GetEmployee(eid);
            if(employee == null)
            {
                Console.WriteLine("Employee not found");
                return null;
            }
            for (int i = 0; i < count; i++)
            {
                if(issues[i].ReportedBy == eid)
                    raisedissues[i] = issues[i];
            }
            return raisedissues;
        }

        public bool RaiseIssue(int eid, Issue issue)
        {
            Employee employee =GetEmployee(eid);
            if (employee!= null)
            {
                issue.ReportedBy = employee.Id;
                if(count<10)
                {
                    issues[count] = issue;
                    issues[count].Id = count + 1;
                }
                count++;
                return true;
            }
            Console.WriteLine("Unable to raise issue");
            return false;


        }

        public Issue[] GetAllIssues()
        {
            if(count == 0)
            {
                Console.WriteLine("No issues found");
                return null;
            }
            return issues;
        }

        public Issue AssignIssue(int eid, int issueId)
        {
            Employee employee = GetEmployee(eid);
            if (employee == null)
            {
                Console.WriteLine("Employee  for assigning iussue not found");
                return null;
            }
            Issue myIssue = GetIssueById(issueId);
            if (myIssue == null)
            {
                Console.WriteLine("Issue not found");
                return null;
            }
            bool checkDesignation = CheckSolverDesignation(employee);
            if (checkDesignation &&  myIssue.AssignIssue(eid))
            {
                return myIssue;
            }
            return null;
        }

        private bool CheckSolverDesignation(Employee employee)
        {
            if (employee.Designation == "Manager" || employee.Designation == "Team Lead")
            {
                return true;
            }
            return false;
        }

        
    }
}
