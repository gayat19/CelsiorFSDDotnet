using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{

    public class DuplicateUsernameException : Exception
    {
        string msg;
        public override string Message => msg;
        public DuplicateUsernameException()
        {
            msg = "Username already exists";
        }


    }
}