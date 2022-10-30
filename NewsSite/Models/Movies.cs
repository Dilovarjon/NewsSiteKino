namespace NewsSite.Models
{
    public class Movies
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Opisanies { get; set; } = string.Empty;

        public Category? Category { get; set; }
        public Genres? Genres { get; set; }

    }
}
