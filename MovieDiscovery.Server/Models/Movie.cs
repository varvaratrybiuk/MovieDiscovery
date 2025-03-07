using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieDiscovery.Server.Models
{
    /// <summary>
    /// Сутність, що представляє фільм.
    /// </summary>
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        /// <summary>
        /// Унікальний ідентифікатор фільму.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Назва фільму.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Опис фільму.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Рік випуску фільму.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Рейтинг фільму.
        /// </summary>
        public float? Rating { get; set; }

        /// <summary>
        /// Колекція, що зберігає зв'язки між фільмами та жанрами.
        /// </summary>
        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }
    }
}
