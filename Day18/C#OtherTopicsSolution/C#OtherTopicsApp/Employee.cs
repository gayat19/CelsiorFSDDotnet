using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_OtherTopicsApp
{
    internal class Employee : IDisposable
    {
        public string Name { get; set; }
        List<string> Skills { get; set; }

        Leave leave = new Leave();



        //indexer
        public string this[int index]
        {
            get { return Skills[index]; }
            set { Skills[index] = value; }
        }

        public int this[string skillname]
        {
            get 
            {
                int idx = -1;
                for (int i = 0; i < Skills.Count; i++)
                {
                    if (Skills[i] == skillname)
                    {
                        idx = i;
                        break;
                    }
                }
                return idx;
            }
            
        }
        public Employee()
        {
            Console.WriteLine("Employee created");
            Name = "Ramu";
            Skills = new List<string>() { "C#", "ASP.NET", "MVC", "SQL Server"};
            leave.SickLeave = 10;
            leave.CasualLeave = 10;
        }
        //used to release unmanaged resources
        ~Employee()
        {
            Console.WriteLine("Employee destroyed");
        }
        //used to release unmanaged resources
        public void Dispose()
        {
            Console.WriteLine("This is the dispose method");
        }

        public bool AvailSickLeave(int days)
        {
            if(leave.SickLeave >= days)
            {
                leave.SickLeave -= days;
                return true;
            }
            return false;
        }
        class Leave
        {
            public int CasualLeave { get; set; }
            public int SickLeave { get; set; }
        }
    }
}
