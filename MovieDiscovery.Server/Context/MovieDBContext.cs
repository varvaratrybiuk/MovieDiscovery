using Microsoft.EntityFrameworkCore;
using MovieDiscovery.Server.Models;

namespace MovieDiscovery.Server.Context
{
    /// <summary>
    /// Контекст бази даних для роботи з застосунком Movie Discovery.
    /// </summary>
    /// <param name="dbContext">Конфігураційні параметри контексту бази даних.</param>
    public class MovieDBContext(DbContextOptions<MovieDBContext> dbContext) : DbContext(dbContext)
    {
        /// <summary>
        /// Колекція фільмів у базі даних.
        /// </summary>
        public DbSet<Movie> Movies { get; set; }

        /// <summary>
        /// Колекція жанрів у базі даних.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Колекція зв’язків між фільмами та жанрами.
        /// </summary>
        public DbSet<Movie_Genre> Movies_Genres { get; set; }

        /// <summary>
        /// Колекція користувачів у базі даних.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Заповнення початковими даними.
        /// </summary>
        /// <param name="modelBuilder">Об'єкт для конфігурації моделі.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Id = 1, Name = "Фентезі" },
                new Genre { Id = 2, Name = "Музичні" },
                new Genre { Id = 3, Name = "Мелодрами" },
                new Genre { Id = 4, Name = "Сімейний" },
                new Genre { Id = 5, Name = "Дитячий" },
                new Genre { Id = 6, Name = "Екшн" },
                new Genre { Id = 7, Name = "Комедія" },
                new Genre { Id = 8, Name = "Пригоди" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title = "Чародійка",
                    Description = "Ми переносимося в Країну Оз і знайомимося з відьмою...",
                    Year = 2024,
                    Rating = 7.6f
                },
                new Movie
                {
                    Id = 2,
                    Title = "Барбі",
                    Description = "Барбіленд – напрочуд прекрасний світ...",
                    Year = 2023,
                    Rating = 6.8f
                },
                new Movie
                {
                    Id = 3,
                    Title = "Школа монстрів: 13 бажань",
                    Description = "Мультфільм «Школа монстрів: 13 бажань» продовжує розповідати...",
                    Year = 2013,
                    Rating = 6.9f
                },
                new Movie
                {
                    Id = 4,
                    Title = "Школа монстрів: Бу Йорк, Бу Йорк",
                    Description = "Пригоди студентів незвичайного навчального закладу...",
                    Year = 2015,
                    Rating = 6.7f
                },
                new Movie
                {
                    Id = 5,
                    Title = "Школа монстрів: Привиди",
                    Description = "Незвичайний анімаційний мультфільм Школа монстрів: Привиди...",
                    Year = 2015,
                    Rating = 6.3f
                }
            );

            modelBuilder.Entity<Movie_Genre>().HasData(
                new Movie_Genre { Id = 1, MovieId = 1, GenreId = 1, UserId = null },
                new Movie_Genre { Id = 2, MovieId = 1, GenreId = 2, UserId = null },
                new Movie_Genre { Id = 3, MovieId = 1, GenreId = 3, UserId = null },
                new Movie_Genre { Id = 4, MovieId = 2, GenreId = 3, UserId = null },
                new Movie_Genre { Id = 5, MovieId = 2, GenreId = 6, UserId = null },
                new Movie_Genre { Id = 6, MovieId = 2, GenreId = 7, UserId = null },
                new Movie_Genre { Id = 7, MovieId = 2, GenreId = 8, UserId = null },
                new Movie_Genre { Id = 8, MovieId = 3, GenreId = 1, UserId = null },
                new Movie_Genre { Id = 9, MovieId = 3, GenreId = 5, UserId = null },
                new Movie_Genre { Id = 10, MovieId = 3, GenreId = 7, UserId = null },
                new Movie_Genre { Id = 11, MovieId = 4, GenreId = 2, UserId = null },
                new Movie_Genre { Id = 12, MovieId = 4, GenreId = 5, UserId = null }
            );
        }
    }

}
