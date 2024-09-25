namespace PizzaStoreAPI.Exceptions
{
    internal class NoEntityFoundException : Exception
    {
        string message;
        public NoEntityFoundException()
        {
            message = "No entity found";
        }
        public NoEntityFoundException(string? entity)
        {
            message = $"No {message} found";
        }

        public NoEntityFoundException(string? message, int key)
        {
            message = $"No {message} found with id {key}";
        }
        override public string Message => message;


    }
}