namespace MovieDiscovery.Server.Contracts.User
{
    /// <summary>
    /// Об'єкт, що представляє запит для здійснення входу у систему.
    /// </summary>
    public record UserRequest
    {
        /// <summary>
        /// Ім'я користувача.
        /// </summary>
        public required string Username { get; init; }

        /// <summary>
        /// Пароль користувача.
        /// </summary>
        public required string Password { get; init; }
    }
}
