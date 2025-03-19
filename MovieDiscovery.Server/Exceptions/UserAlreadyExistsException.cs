namespace MovieDiscovery.Server.Exceptions
{
    /// <summary>
    /// Виключення, яке виникає, коли користувач з таким ім'ям або електронною поштою вже існує.
    /// </summary>
    public class UserAlreadyExistsException : Exception
    {
        /// <summary>
        /// Конструктор для виключення <see cref="UserAlreadyExistsException"/>.
        /// </summary>
        public UserAlreadyExistsException()
            : base("Користувач із таким іменем або електронною поштою вже існує.") { }
    }
}
