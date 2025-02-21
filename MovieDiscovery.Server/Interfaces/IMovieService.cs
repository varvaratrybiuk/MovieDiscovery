using api.Contracts;

namespace api.Interfaces
{
    public interface IMovieService
    {
        Task<MovieResponse> AddMovieAsync(CreateMovieRequest movieRequest);
        Task<MovieResponse?> GetRandomMovieAsync();
        Task<MovieResponse?> GetByTitleAsync(string title);
        Task<IEnumerable<MovieResponse>> GetAllAsync();
    }
}
