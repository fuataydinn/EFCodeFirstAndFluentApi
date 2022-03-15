using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstBasics.Models
{
    //Code First ile modeli olusturmak icin
    //1. Nuget'ten gerekli paketleri kur
    //2. Entity sınıfları ve Dbcontext'i olustur
    //3. Migration paketini (paketlerini) olustur
    //4. Veritabanını güncelle
   public class RebelsDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RebelsDb;Integrated Security=true;");
        }
    }
}
