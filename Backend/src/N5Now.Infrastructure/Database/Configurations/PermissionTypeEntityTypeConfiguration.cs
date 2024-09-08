using N5Now.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace N5Now.Infrastructure.Database.Configurations
{
    public class PermissionTypeEntityTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
