namespace BlogPlatform.Exceptions
{
    public class AlreadyExistsBlogPosts:  Exception
    {

        string _message;
        public AlreadyExistsBlogPosts(string entityName)
        {
            _message = $"{entityName} The item already exits";
        }


        override public string Message => _message;
    }
}
