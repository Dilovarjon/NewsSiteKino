// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewsSite.Controllers;

#nullable disable

namespace NewsSite.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NewsSite.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NewsSite.Models.Genres", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("55f02370-2b69-4494-9c28-74b8f9b32fa5"),
                            Name = "Аниме"
                        },
                        new
                        {
                            Id = new Guid("ae7cd0f6-01d2-4bdd-9d8a-2d224bf7418a"),
                            Name = "Мультфильмы"
                        },
                        new
                        {
                            Id = new Guid("35b29062-c601-42e4-853d-c685ac8f0ba9"),
                            Name = "Биографический"
                        },
                        new
                        {
                            Id = new Guid("ee2f61fd-ffc7-4bf3-9b9b-f5c3d5378b8a"),
                            Name = "Боевик"
                        },
                        new
                        {
                            Id = new Guid("13593721-bb39-4174-bdfc-246d245de09a"),
                            Name = "Война"
                        },
                        new
                        {
                            Id = new Guid("ff1facee-e85e-4c46-ba38-c778a56e71cc"),
                            Name = "Детектив"
                        });
                });

            modelBuilder.Entity("NewsSite.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<Guid?>("GenresId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Opisanie")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("GenresId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("NewsSite.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9ca7d89c-94fd-45fd-bd0c-8dfa60686279"),
                            Name = "admin"
                        },
                        new
                        {
                            Id = new Guid("19f0ed43-48f5-4b5e-a90d-1fd8715cabd0"),
                            Name = "user"
                        });
                });

            modelBuilder.Entity("NewsSite.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Age")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid?>("RoleId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NewsSite.Models.Movie", b =>
                {
                    b.HasOne("NewsSite.Models.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId");

                    b.HasOne("NewsSite.Models.Genres", "Genres")
                        .WithMany("Movies")
                        .HasForeignKey("GenresId");

                    b.Navigation("Category");

                    b.Navigation("Genres");
                });

            modelBuilder.Entity("NewsSite.Models.User", b =>
                {
                    b.HasOne("NewsSite.Models.Role", "Role")
                        .WithMany("Persons")
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NewsSite.Models.Category", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("NewsSite.Models.Genres", b =>
                {
                    b.Navigation("Movies");
                });

            modelBuilder.Entity("NewsSite.Models.Role", b =>
                {
                    b.Navigation("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
