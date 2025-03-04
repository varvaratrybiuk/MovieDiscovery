using MovieDiscovery.Server.Contracts;

namespace MovieDiscovery.Server.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponse> AddMovieAsync(CreateMovieRequest movieRequest);
        Task<MovieResponse?> GetRandomMovieAsync();
        Task<MovieResponse?> GetByTitleAsync(string title);
        Task<IEnumerable<MovieResponse>> GetAllAsync();
    }
}
