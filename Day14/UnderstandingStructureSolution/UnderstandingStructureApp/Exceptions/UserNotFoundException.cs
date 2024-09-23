using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException()
        {
            msg = "User with the given username not found";
        }

        string msg;
        public override string Message => msg;
    }
}