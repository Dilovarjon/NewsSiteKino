namespace NewsSite.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public string Opisanie { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public Genres? Genres { get; set; }

    }
}
