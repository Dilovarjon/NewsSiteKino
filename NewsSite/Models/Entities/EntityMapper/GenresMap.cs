using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsSite.Enums;

namespace NewsSite.Models.Entities.EntityMapper
{
    public class GenresMap : IEntityTypeConfiguration<Genres>
    {
        public void Configure(EntityTypeBuilder<Genres> builder)
        {
            builder.HasData(
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
