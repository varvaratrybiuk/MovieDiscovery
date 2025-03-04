using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDiscovery.Server.Models
{
    public class Movie_Genre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual User? User { get; set; }
    }
}
