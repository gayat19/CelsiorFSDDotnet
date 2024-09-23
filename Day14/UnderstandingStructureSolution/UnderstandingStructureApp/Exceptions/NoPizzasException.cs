using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{
    
    public class NoPizzasException : Exception
    {
       
        public NoPizzasException()
        {
            msg = "There are no more pizzas left. You ate them all!";

        }
        string msg;
        public override string Message => msg;

    }
}