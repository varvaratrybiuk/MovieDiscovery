using MovieDiscovery.Server.Contracts;

namespace MovieDiscovery.Server.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetAllAsync();
    }
}
