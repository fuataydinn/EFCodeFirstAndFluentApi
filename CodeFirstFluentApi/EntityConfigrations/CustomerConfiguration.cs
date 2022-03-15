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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(cus => cus.Id);

            builder.Property(cus => cus.Name)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(cus => cus.Adrress)
                .HasMaxLength(4000);
        }
    }
}
