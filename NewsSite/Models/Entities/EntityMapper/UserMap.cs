using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsSite.Enums;

namespace NewsSite.Models.Entities.EntityMapper
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
            new User
            {
                Id = Guid.NewGuid(),
                Name = "admin",
                Age = "12",
                Login = "admin",
                Password = "12345",
                PhoneNumber = "",
                RoleId = RoleEnum.IdAdmin,
            });
        }
    }
}
