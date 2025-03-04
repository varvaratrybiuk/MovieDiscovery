namespace MovieDiscovery.Server.Contracts
{
    public record UserRequest
    {
        public required string Username { get; init; }
        public required string Password { get; init; }
    }
}
