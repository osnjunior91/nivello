using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivello.Infrastructure.Data.Model;

namespace Nivello.Infrastructure.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products").HasKey(x => x.Id);
            builder.HasOne(x => x.SystemAdmin)
                .WithMany().HasForeignKey(x => x.SystemAdminId);
        }
    }
}
