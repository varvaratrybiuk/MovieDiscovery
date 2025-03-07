using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieDiscovery.Server.Models
{
    /// <summary>
    /// Сутність, що представляє користувача в системі.
    /// </summary>
    [Index(nameof(Username), nameof(Email), IsUnique = true)]
    public class User
    {
        /// <summary>
        /// Унікальний ідентифікатор користувача.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Ім'я користувача.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Електронна пошта користувача.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Хеш пароля користувача.
        /// </summary>
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Колекція, що зберігає зв'язки між користувачами, фільмами та жанрами.
        /// </summary>
        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }
    }
}
