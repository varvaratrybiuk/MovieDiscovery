namespace MovieDiscovery.Server.Contracts.Genre
{
    /// <summary>
    /// Представляє відповідь, що містить основну інформацію про жанр.
    /// </summary>
    public record GenreResponse
    {
        /// <summary>
        /// Унікальний ідентифікатор жанру.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Назва жанру.
        /// </summary>
        public required string Name { get; set; }
    }
}