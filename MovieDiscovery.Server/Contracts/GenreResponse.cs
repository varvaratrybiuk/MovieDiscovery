namespace MovieDiscovery.Server.Contracts
{
    public record GenreResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}