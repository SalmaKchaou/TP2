namespace TP2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Guid? GenreId { get; set; } // foreign key 
        public Genre Genre { get; set; }  // Navigation property
        public Movie()
        {
        }
    }
}
