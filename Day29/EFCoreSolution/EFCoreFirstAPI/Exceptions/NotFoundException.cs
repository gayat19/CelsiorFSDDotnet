namespace EFCoreFirstAPI.Exceptions
{
    public class NotFoundException : Exception
    {
        string _message;
        public NotFoundException(string entityName)
        {
            _message = $"{entityName} could not be found";
        }
        override public string Message => _message;
    }
}
