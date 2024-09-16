using System.Runtime.Serialization;

namespace UnderstandingOOPSApp
{
    internal class NoSuchEmployeeException : Exception
    {
        string msg;
        public NoSuchEmployeeException()
        {
            msg = "Issue not found";
        }
        public override string Message => msg;
    }
}