using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsSite.Enums;

namespace NewsSite.Models.Entities.EntityMapper
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
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
        }
    }
}
