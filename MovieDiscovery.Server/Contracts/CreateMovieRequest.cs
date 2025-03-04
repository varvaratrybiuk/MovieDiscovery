namespace MovieDiscovery.Server.Contracts
{
    public record CreateMovieRequest
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public required List<int> GenresID { get; init; }
        public int Year { get; init; }
        public float? Rating { get; init; }
    }
}
