using System.Runtime.Serialization;

namespace UnderstandingStructureApp.Exceptions
{

    public class CannotUpdateWithNoImagesException : Exception
    {
        string msg;
        public override string Message => msg;
        public CannotUpdateWithNoImagesException()
        {
            msg = "Cannot update a pizza with no images";
        }

        
    
    }
}