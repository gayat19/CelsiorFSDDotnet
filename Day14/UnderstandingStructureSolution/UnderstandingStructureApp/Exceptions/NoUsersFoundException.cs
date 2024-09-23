using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{

    public class NoUsersFoundException : Exception
    {
        public NoUsersFoundException()
        {
            msg = "No users available";
        }

        string msg;
        public override string Message => msg;
    }
}