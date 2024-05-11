using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatweer_eCommerceTask.Core.Entities;

namespace Tatweer_eCommerceTask.Repository.Data.Config
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
             builder.Property(P => P.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(P => P.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(P => P.IsVisible)
                .IsRequired();
        }
    }
}
