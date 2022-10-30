﻿namespace NewsSite.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role? Role { get; set; }
    }
}
