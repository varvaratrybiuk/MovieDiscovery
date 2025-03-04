using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MovieDiscovery.Server.Models
{
    [Index(nameof(Username), nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }
    }
}
