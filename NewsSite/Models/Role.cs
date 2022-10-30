namespace NewsSite.Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Person> Persons { get; set; } = new();
    }
}
