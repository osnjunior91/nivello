using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivello.Infrastructure.Data.Model;
using System.Diagnostics.CodeAnalysis;

namespace Nivello.Infrastructure.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class AuctionsBidConfiguration : IEntityTypeConfiguration<AuctionsBid>
    {
        public void Configure(EntityTypeBuilder<AuctionsBid> builder)
        {
            builder.ToTable("auctions-bid").HasKey(x => x.Id);
            
            builder.HasOne(x => x.Product)
                .WithMany().HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Customer)
                .WithMany().HasForeignKey(x => x.CustomerId);
        }
    }
}
