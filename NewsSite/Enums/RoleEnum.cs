namespace NewsSite.Enums
{
    public class RoleEnum
    {
        public static Guid IdAdmin { get; } = Guid.Parse("9CA7D89C-94FD-45FD-BD0C-8DFA60686279");
        public static string AdminName { get; } = "Admin";
        public static Guid IdUser { get; } = Guid.Parse("19F0ED43-48F5-4B5E-A90D-1FD8715CABD0");
        public static string UserName { get; } = "User";
    }
}
