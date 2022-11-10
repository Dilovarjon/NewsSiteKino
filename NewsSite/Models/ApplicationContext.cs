using Microsoft.EntityFrameworkCore;
using NewsSite.Models;
using NewsSite.Models.Entities.EntityMapper;

namespace NewsSite.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;

        
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            //Database.EnsureCreated();   // создаем базу данных при первом обращении
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Добавление в базу Данных Роли
            modelBuilder.ApplyConfiguration(new RoleMap());

            // Добавление в базу данных аккаунт Admina
            modelBuilder.ApplyConfiguration(new UserMap());

            // Добавление  в базу данных Жанров
            modelBuilder.ApplyConfiguration(new GenresMap());    

            // Добовление в базу данных Жанры
            modelBuilder.ApplyConfiguration(new CategoryMap());
        }
    }
}
