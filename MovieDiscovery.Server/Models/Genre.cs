using System.ComponentModel.DataAnnotations;

namespace MovieDiscovery.Server.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public virtual IList<Movie_Genre>? MoviesGenres { get; set; }
    }
}
