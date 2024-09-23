namespace UnderstandingStructureApp.Exceptions
{
    public class NoSuchPizzaException : Exception
    {
        string msg;
        public NoSuchPizzaException()
        {
            msg = "Pizza withthe given details not found in the repository";
        }
        public override string Message => msg;
    }
}
