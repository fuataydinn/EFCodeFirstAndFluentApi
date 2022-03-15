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
    public class SupplierConfigration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(sup => sup.Id);
            builder.Property(sup => sup.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(sup => sup.Address)
                .HasMaxLength(4000);
        }
    }
}
