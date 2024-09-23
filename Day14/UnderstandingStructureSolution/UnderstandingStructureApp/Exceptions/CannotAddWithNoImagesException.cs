using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{
    
    public class CannotAddWithNoImagesException : Exception
    {
        string msg;
        public CannotAddWithNoImagesException()
        {
            msg = "Cannot add a images object with no images";
        }
        public override string Message => msg;

    }
}