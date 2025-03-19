using System.ComponentModel.DataAnnotations;

namespace MovieDiscovery.Server.Models
{
    /// <summary>
    /// Сутність, що представляє жанр фільму.
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Унікальний ідентифікатор жанру.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Назва жанру.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Колекція, що зберігає зв'язки між жанрами та фільмами.
        /// </summary>
        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }
    }
}
