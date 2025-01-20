namespace BankingApplication.Exceptions
{
    public class CouldNotAddException : Exception
    {
        string message;
        public CouldNotAddException(string message)
        {
            this.message = message;
        }

        public override string Message => message;
    }
}
