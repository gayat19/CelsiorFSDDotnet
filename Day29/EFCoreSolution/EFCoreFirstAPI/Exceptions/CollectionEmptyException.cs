namespace EFCoreFirstAPI.Exceptions
{
    public class CollectionEmptyException :Exception
    {
        string _message;
        public CollectionEmptyException(string entityName)
        {
            _message = $"This collection is empty -  {entityName}";
        }
        override public string Message => _message;
    }
}
