using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Context;
using MovieDiscovery.Server.Contracts.Movie;
using MovieDiscovery.Server.Exceptions;
using MovieDiscovery.Server.Interfaces;
using MovieDiscovery.Server.Models;

namespace MovieDiscovery.Server.Services
{
    /// <summary>
    /// Сервіс для роботи з фільмами.
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly MovieDBContext _context;

        /// <summary>
        /// Ініціалізує новий екземпляр <see cref="MovieService"/>.
        /// </summary>
        /// <param name="context">Контекст бази даних.</param>
        public MovieService(MovieDBContext context) => _context = context;

        /// <summary>
        /// Додавання нового фільму у базу даних.
        /// </summary>
        /// <param name="movieRequest">Дані фільму для створення.</param>
        /// <param name="userId">Ідентифікатор користувача, який додає фільм.</param>
        /// <returns>Об'єкт <see cref="MovieResponse"/> із даними збереженого фільму.</returns>
        /// <exception cref="ArgumentNullException">Виникає, якщо <paramref name="movieRequest"/> є null.</exception>
        /// <exception cref="MovieAlreadyExistsException">Виникає, якщо фільм із таким заголовком уже існує.</exception>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
        public async Task<MovieResponse> AddMovieAsync(CreateMovieRequest movieRequest, int userId)
        {
            ArgumentNullException.ThrowIfNull(movieRequest);

            try
            {
                var result = await GetByTitleAsync(movieRequest.Title);

                if (result is not null)
                {
                    throw new MovieAlreadyExistsException(movieRequest.Title);
                }
            }
            catch (MovieNotFoundException) { }

            var movie = new Movie()
            {
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
                GenreId = genreId,
                UserId = userId
            }).ToList();

            _context.Movies_Genres.AddRange(movieGenres);
            await _context.SaveChangesAsync();

            var genres = await _context.Movies_Genres
                .Include(mg => mg.Genre)
                .Where(mg => mg.MovieId == movie.Id)
                .Select(mg => mg.Genre.Name)
                .ToListAsync();

            return new MovieResponse()
            {
                Id = movie.Id,
                Title = movieRequest.Title,
                Year = movieRequest.Year,
                Genres = genres,
                Description = movieRequest.Description,
                Rating = movieRequest.Rating
            };
        }

        /// <summary>
        /// Отримання списку усіх фільмів разом із жанрами.
        /// </summary>
        /// <returns>Колекція об'єктів <see cref="MovieResponse"/>.</returns>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
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

        /// <summary>
        /// Отримання фільму за його заголовком.
        /// </summary>
        /// <param name="title">Назва фільму.</param>
        /// <returns>Об'єкт <see cref="MovieResponse"/> або викликає виняток.</returns>
        /// <exception cref="ArgumentNullException">Виникає, якщо <paramref name="title"/> є null або порожнім.</exception>
        /// <exception cref="MovieNotFoundException">Виникає, якщо фільм не знайдено.</exception> 
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
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

        /// <summary>
        /// Отримання випадкового фільму із бази даних.
        /// </summary>
        /// <returns>Об'єкт <see cref="MovieResponse"/>.</returns>
        /// <exception cref="NoMoviesFoundException">Виникає, якщо у базі немає фільмів.</exception>
        /// <exception cref="Exception">Може виникнути у разі неочікуваної помилки.</exception>
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
