using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp
{
    public class InvalidInputDetailException:Exception //Custom Exception or User defined Exception
    {
        string message;
        public InvalidInputDetailException()
        {
            message = "The details entered are invalid. Please try again.";
        }
        //public override string Message
        //{
        //    get
        //    {
        //        return message;
        //    }
        //}

        public override string Message => message;//Lambda Expression or arrow function
    }
}
