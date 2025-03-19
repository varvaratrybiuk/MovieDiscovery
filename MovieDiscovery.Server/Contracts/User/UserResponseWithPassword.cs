namespace MovieDiscovery.Server.Contracts.User
{
    /// <summary>
    /// Представляє відповідь, яка містить основну інформацію про користувача та його пароль.
    /// </summary>
    public record UserResponseWithPassword : UserResponse
    {
        /// <summary>
        /// Пароль користувача.
        /// </summary>
        public required string Password { get; init; }
    }
}
