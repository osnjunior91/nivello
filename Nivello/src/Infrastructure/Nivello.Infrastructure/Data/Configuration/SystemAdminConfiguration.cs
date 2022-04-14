using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivello.Infrastructure.Data.Model;

namespace Nivello.Infrastructure.Data.Configuration
{
    public class SystemAdminConfiguration : IEntityTypeConfiguration<SystemAdmin>
    {
        public void Configure(EntityTypeBuilder<SystemAdmin> builder)
        {
            builder.ToTable("administrators").HasKey(x => x.Id);
        }
    }
}
