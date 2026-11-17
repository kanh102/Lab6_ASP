using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.ComponentModel.DataAnnotations;

namespace Lab6_movie.Models
{
    public class Moviecs
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2, ErrorMessage = "Title must be")]
        public string Title { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        //Navigation property for the related genre
        public Genre? Genre { get; set; }
    }
}
