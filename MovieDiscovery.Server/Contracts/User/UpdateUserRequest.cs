namespace MovieDiscovery.Server.Contracts.User
{
    /// <summary>
    /// Об'єкт, що представляє запит для оновлення даних користувача.
    /// </summary>
    public record UpdateUserRequest
    {
        /// <summary>
        /// Нове ім'я користувача (необов'язково).
        /// </summary>
        public string? Username { get; init; }

        /// <summary>
        /// Нова електронна пошта користувача (необов'язково).
        /// </summary>
        public string? Email { get; init; }

        /// <summary>
        /// Новий пароль користувача (необов'язково).
        /// </summary>
        public string? Password { get; init; }
    }
}
