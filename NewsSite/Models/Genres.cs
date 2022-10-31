﻿namespace NewsSite.Models
{
    public class Genres
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<Movie> Movies { get; set; } = new();
    }
}
