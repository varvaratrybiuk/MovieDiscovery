using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Movie_Genre
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public virtual Genre? Genre { get; set; }
        public virtual Movie? Movie { get; set; }
    }
}
