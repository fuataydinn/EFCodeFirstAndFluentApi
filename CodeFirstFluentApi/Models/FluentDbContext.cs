using CodeFirstFluentApi.EntityConfigrations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstFluentApi.Models
{
    public class FluentDbContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=FluentDb;Integrated Security=true;";
        public DbSet<Category> Categories { get; set; } //Repository
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categoryBuilder = modelBuilder.Entity<Category>();
            categoryBuilder.HasKey(cat => cat.Id);
            categoryBuilder.Property(cat => cat.Name).IsRequired().HasMaxLength(100).HasColumnType("varchar");

            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder.HasKey(prod => prod.Id);
            productBuilder.Property(prod => prod.Name).IsUnicode(false).IsRequired();
            productBuilder.Property(prod => prod.UnitPrice)
                .HasColumnType("money")
                .HasColumnName("Price"); //Tablo ismi bu olsun dedik 
            productBuilder.Property(prod => prod.UnitsInStock)
                .HasDefaultValue((short)0);

            //Ne product ne de category sınıfında Navigation Property tanımlanmamıs olsaydı asagıdaki gibi FK yapısınıu kurgulayabilirdim

            //productBuilder.HasOne<Category>()
            //    .WithMany()
            //    .HasForeignKey(prod => prod.CategoryId);

            //Fk yapıyoruz burada 
            productBuilder.HasOne(prod => prod.Category)
                //.WithMany()
                .WithMany(cat => cat.Products) //kategorının cok productı vardır ondan bunu yaptık
                .HasForeignKey(prod => prod.CategoryId) //Kafana gore FK kolonu olusturma, bu property uzerınde FK olustur
                .HasConstraintName("FK_Product_TO_Category")
                .OnDelete(DeleteBehavior.Cascade);  //Categorey silinirse productlarda silinecek o kategori ile ilgili productlar

            modelBuilder.ApplyConfiguration(new SupplierConfigration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfigration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
