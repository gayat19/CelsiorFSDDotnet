using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{
    [Serializable]
    internal class NoSuchImageException : Exception
    {
        public NoSuchImageException()
        {
            msg = "No such image exists";
        }

        string msg;
        public override string Message => msg;
    }
}