namespace EFCoreFirstAPI.Exceptions
{
    public class CouldNotAddException : Exception
    {
        string _message;
        public CouldNotAddException(string entityName) 
        {
            _message = $"Could not add {entityName}";
        }
        override public string Message => _message;
    }
}
