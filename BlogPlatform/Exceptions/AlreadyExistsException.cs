namespace BlogPlatform.Exceptions
{
    public class AlreadyExistsException : Exception

    {

        string _message;
        public AlreadyExistsException(string message)
        {
           this._message = message;
        }


        override public string Message => _message;


    }
}
