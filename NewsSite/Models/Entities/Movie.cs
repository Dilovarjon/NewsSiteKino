namespace NewsSite.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; } 
        public string Path { get; set; }
        public string Opisanie { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        public Guid GenresId { get; set; }
        public Genres? Genres { get; set; }

    }
}
