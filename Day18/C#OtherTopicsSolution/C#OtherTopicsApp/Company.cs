using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_OtherTopicsApp
{
    internal class Company
    {
        public static int NumberOfEmployees { get; set; }
        public string CompanyName { get; set; }
        //Used to initialize the static members of the class
        static Company()
        {
            NumberOfEmployees = 10;
            //CompanyName = "Microsoft";//Instance member cannot be accessed in a static constructor
        }
        public Company()
        {
            
        }
    }
}
