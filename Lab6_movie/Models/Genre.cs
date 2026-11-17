namespace Lab6_movie.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //Navigation property for the related movies
        public ICollection<Moviecs> Movies { get; set; } = new List<Moviecs>();
    }
}
