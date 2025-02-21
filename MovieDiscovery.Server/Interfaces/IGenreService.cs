using api.Contracts;

namespace api.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponse>> GetAllAsync();
    }
}
