using Microsoft.EntityFrameworkCore;
namespace NewsSite.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Movies> Movies { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // Добавление в базу Данных Роли
            model.Entity<Role>().HasData(
                new Role
                {
                    Id = RoleEnum.IdAdmin,
                    Name = RoleEnum.AdminName
                },
                new Role
                {
                    Id = RoleEnum.IdUser,
                    Name = RoleEnum.UserName
                });

            
            
            // Добовление в базу данных Жанры
            model.Entity<Genres>().HasData(
                new Genres
                {
                    Id = GengeresEnum.IdAnime,
                    Name = GengeresEnum.NameAnime
                },
                new Genres
                {
                    Id = GengeresEnum.IdMultfilm,
                    Name = GengeresEnum.NameMultfilm
                },
                new Genres
                {
                    Id = GengeresEnum.IdBiograf,
                    Name = GengeresEnum.NameBiograf
                },
                new Genres
                {
                    Id = GengeresEnum.IdBoevik,
                    Name = GengeresEnum.NameBoevik
                },
                new Genres
                {
                    Id = GengeresEnum.IdVoina,
                    Name = GengeresEnum.NameVoina
                },
                new Genres
                {
                    Id = GengeresEnum.IdDetektiv,
                    Name = GengeresEnum.NameDetektiv
                });


        }
    }
}
