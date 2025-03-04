namespace MovieDiscovery.Server.Contracts
{
    public record UserResponseWithPassword : UserResponse
    {
        public required string Password { get; init; }
    }
}
