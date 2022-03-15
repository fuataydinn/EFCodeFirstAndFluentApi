using CodeFirstFluentApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentApi.EntityConfigrations
{
    class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(od => new { od.OrderId, od.ProductId });
            builder.Property(od => od.Quantity).HasColumnType("smallint");
            builder.Property(od => od.UnitPrice).HasColumnType("money");
            builder.Property(od => od.Discount).HasColumnType("smallint");
        }
    }
}
