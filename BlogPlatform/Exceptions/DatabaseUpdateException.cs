namespace BlogPlatform.Exceptions
{
    public class DatabaseUpdateException : Exception
    {
        string _message;
        public DatabaseUpdateException(string message, Exception innerException)
         {
            _message = $" could not update  database";

        }

    }
}
