namespace MovieDiscovery.Server.Contracts.User
{
    /// <summary>
    /// Представляє відповідь, яка містить основну інформацію про користувача.
    /// </summary>
    public record UserResponse
    {
        /// <summary>
        /// Унікальний ідентифікатор користувача.
        /// </summary>
        public int Id { get; init; }

        /// <summary>
        /// Ім'я користувача, яке використовується для авторизації.
        /// </summary>
        public required string Username { get; init; }

        /// <summary>
        /// Адреса електронної пошти користувача.
        /// </summary>
        public required string Email { get; init; }
    }

}
