namespace NewsSite.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<User> Persons { get; set; } = new();
    }
}
