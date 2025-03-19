namespace MovieDiscovery.Server.Contracts.User
{
    /// <summary>
    /// Об'єкт, що представляє запит для створення нового користувача.
    /// </summary>
    public record CreateUserRequest
    {
        /// <summary>
        /// Ім'я користувача.
        /// </summary>
        public required string Username { get; init; }

        /// <summary>
        /// Електронна пошта користувача.
        /// </summary>
        public required string Email { get; init; }

        /// <summary>
        /// Пароль користувача.
        /// </summary>
        public required string Password { get; init; }
    }
}
