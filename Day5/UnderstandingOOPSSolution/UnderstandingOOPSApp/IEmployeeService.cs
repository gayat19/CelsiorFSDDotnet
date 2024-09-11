using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApp
{
    internal interface IEmployeeService
    {
        public bool RaiseIssue(int eid, Issue issue);
        public bool CloseIssue(int eid, Issue issue);
        public Issue[] GetAllIssues(int eid);
    }
}
