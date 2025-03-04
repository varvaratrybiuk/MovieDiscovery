namespace MovieDiscovery.Server.Contracts
{
    public record MovieResponse
    {
        public int Id { get; init; }
        public required string Title { get; init; }
        public string? Description { get; init; }
        public required List<string> Genres { get; init; }
        public int Year { get; init; }
        public float? Rating { get; init; }
    }
}
