using api.Context;
using api.Contracts;
using api.Exceptions;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Exceptions;

namespace api.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDBContext _context;

        public MovieService(MovieDBContext context) => _context = context;
        public async Task<MovieResponse> AddMovieAsync(CreateMovieRequest movieRequest)
        {
            ArgumentNullException.ThrowIfNull(movieRequest);
            var result = await GetByTitleAsync(movieRequest.Title);

            if(result is not null){

                throw new MovieAlreadyExistsException(movieRequest.Title);
            }
            var movie = new Movie() { 
                Title = movieRequest.Title,
                Year = movieRequest.Year,
                Description = movieRequest.Description,
                Rating = movieRequest.Rating,
            };
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            movie = await _context.Movies.Where(m => m.Title == movie.Title).FirstAsync();
            ArgumentNullException.ThrowIfNull(movie);

            var movieGenres = movieRequest.GenresID.Select(genreId => new Movie_Genre()
            {
                MovieId = movie.Id,
                GenreId = genreId
            }).ToList();
             
            _context.Movies_Genres.AddRange(movieGenres);
            await _context.SaveChangesAsync();

            var Genres = await _context.Movies_Genres
                .Include(mg => mg.Genre)
                .Where(mg => mg.MovieId == movie.Id)
                .Select(mg => mg.Genre.Name)
                .ToListAsync();

            return new MovieResponse()
            {
                Id = movie.Id,
                Title = movieRequest.Title,
                Year = movieRequest.Year,
                Genres = Genres,
                Description = movieRequest.Description,
                Rating = movieRequest.Rating
            };
        }

        public async Task<IEnumerable<MovieResponse>> GetAllAsync()
        {
            return await _context.Movies_Genres
            .Include(mg => mg.Genre)
            .Include(mg => mg.Movie)
            .GroupBy(mg => mg.Movie)
            .Select(g => new MovieResponse()
            {
                Id = g.Key.Id,
                Title = g.Key.Title,
                Year = g.Key.Year,
                Genres = g.Select(mg => mg.Genre.Name).ToList(),
                Description = g.Key.Description,
                Rating = g.Key.Rating
            })
            .ToListAsync();
           
        }

        public async Task<MovieResponse?> GetByTitleAsync(string title)
        {
                ArgumentNullException.ThrowIfNullOrWhiteSpace(title, "Film Title");
                var movie = await _context.Movies_Genres
                .Include(mg => mg.Genre)
                .Include(mg => mg.Movie)
                .Where(mg => mg.Movie.Title == title)
                .GroupBy(mg => mg.Movie)
                .Select(g => new MovieResponse()
                {
                    Id = g.Key.Id,
                    Title = g.Key.Title,
                    Year = g.Key.Year,
                    Genres = g.Select(mg => mg.Genre.Name).ToList(),
                    Description = g.Key.Description,
                    Rating = g.Key.Rating
                })
                .FirstOrDefaultAsync();

                return movie is null ? throw new MovieNotFoundException(title) : movie;
        }
        public async Task<MovieResponse?> GetRandomMovieAsync()
        {
                Random random = new();
                var movies = await _context.Movies_Genres
                .Include(mg => mg.Genre)
                .Include(mg => mg.Movie)
                .GroupBy(mg => mg.Movie)
                .Select(g => new MovieResponse()
                {
                    Id = g.Key.Id,
                    Title = g.Key.Title,
                    Year = g.Key.Year,
                    Genres = g.Select(mg => mg.Genre.Name).ToList(),
                    Description = g.Key.Description,
                    Rating = g.Key.Rating
                })
                .ToListAsync();

                if (movies.Count == 0)
                {
                    throw new NoMoviesFoundException();
                }

                int id = random.Next(1, movies.Count);
                return movies[id];
        }
    }
}
