using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDiscovery.Server.Models
{
    /// <summary>
    /// Сутність, що представляє зв'язок між фільмами, жанрами та користувачами.
    /// </summary>
    public class Movie_Genre
    {
        /// <summary>
        /// Унікальний ідентифікатор зв'язку.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Ідентифікатор фільму.
        /// </summary>
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        /// <summary>
        /// Ідентифікатор жанру.
        /// </summary>
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        /// <summary>
        /// Ідентифікатор користувача (необов'язково).
        /// </summary>
        [ForeignKey("User")]
        public int? UserId { get; set; }

        /// <summary>
        /// Жанр, до якого належить фільм.
        /// </summary>
        public virtual Genre? Genre { get; set; }

        /// <summary>
        /// Фільм, до якого належить жанр.
        /// </summary>
        public virtual Movie? Movie { get; set; }

        /// <summary>
        /// Користувач, що додав фільм.
        /// </summary>
        public virtual User? User { get; set; }
    }
}
