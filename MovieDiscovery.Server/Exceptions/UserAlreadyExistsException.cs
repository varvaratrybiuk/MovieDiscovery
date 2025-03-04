namespace MovieDiscovery.Server.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base("Користувач із таким іменем або email вже існує.") { }
    }
}
