using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{
    [Serializable]
    internal class NoImagesException : Exception
    {
        string msg;
        public override string Message => msg;
        public NoImagesException()
        {
            msg = "NO Images with that ID";
        }

       
    }
}