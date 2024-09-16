using System.Runtime.Serialization;

namespace UnderstandingOOPSApp
{

    internal class NoSuchIssueException : Exception
    {
        string msg;
        public NoSuchIssueException()
        {
            msg = "Issue not found";
        }
        public override string Message => msg;


    }
}