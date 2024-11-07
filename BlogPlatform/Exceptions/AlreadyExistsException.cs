namespace BlogPlatform.Exceptions
{
    public class AlreadyExistsException : Exception

    {

        string _message;
        public AlreadyExistsException(string entityName)
        {
            _message = $"{entityName} The item already exits";
        }


        override public string Message => _message;


    }
}
