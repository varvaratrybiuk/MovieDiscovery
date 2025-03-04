namespace MovieDiscovery.Server.Contracts
{
    public record UserResponse
    {
        public int Id { get; init; }
        public required string Username { get; init; }
        public required string Email { get; init; }
    }
}
