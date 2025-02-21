using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public float? Rating { get; set; }

        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }

    }
}
