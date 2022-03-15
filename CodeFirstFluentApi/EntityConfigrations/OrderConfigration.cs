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
    public class OrderConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.EmployeeName).IsRequired().HasMaxLength(150).HasColumnType("varchar");
            builder.Property(o => o.RequiredDate).HasColumnType("datetime");
            builder.HasOne(o => o.Customer)
                .WithMany()
               .HasForeignKey(o => o.CustomerId);
      
               
             
          
        }
    }
}
