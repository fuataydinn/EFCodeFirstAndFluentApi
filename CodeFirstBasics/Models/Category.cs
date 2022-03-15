using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstBasics.Models
{
    [Table("Category")]
    public class Category
    {
        //Atrribute
        /*
         Bir sınıf, property veya metot gibi programlama dilince (C#) temel yapılara ek ozellik kazandırmak icin kullanılan işaretleyiciler

        DataAnnotations(attribute seklinde kullandıgım veri yapılandırıcıları)
        Entity'nin veya propertylerinin ek ozelliklerini bildirmek icin kullandıgımız isaretleyiciler
         */
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [Column(TypeName ="varchar")]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
