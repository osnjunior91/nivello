using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nivello.Infrastructure.Data.Model;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Nivello.Infrastructure.Data.Configuration
{
    [ExcludeFromCodeCoverage]
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customers").HasKey(x => x.Id);

            builder.HasMany(x => x.Bids).WithOne(pk => pk.Customer);
        }
    }
}
