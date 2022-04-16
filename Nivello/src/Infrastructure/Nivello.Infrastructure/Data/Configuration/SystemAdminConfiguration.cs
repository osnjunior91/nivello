using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivello.Infrastructure.Data.Model;
using System.Diagnostics.CodeAnalysis;

namespace Nivello.Infrastructure.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class SystemAdminConfiguration : IEntityTypeConfiguration<SystemAdmin>
    {
        public void Configure(EntityTypeBuilder<SystemAdmin> builder)
        {
            builder.ToTable("administrators").HasKey(x => x.Id);
        }
    }
}
