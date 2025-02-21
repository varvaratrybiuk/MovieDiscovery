using api.Context;
using api.Contracts;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieDBContext _context;

        public GenreService(MovieDBContext context) => _context = context;
        public async Task<IEnumerable<GenreResponse>> GetAllAsync()
        {
            return await _context.Genres
                .Select(g => new GenreResponse
                {
                    Id = g.Id,
                    Name = g.Name
                })
                .ToListAsync();
        }
    }
}
