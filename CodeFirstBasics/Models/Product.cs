using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstBasics.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] //ID kendi vermesin ben elle vereyim
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        [Column(TypeName ="money")]
        public decimal? UnitPrice { get; set; }
        [DefaultValue(0)]
        public short? UnitsInStock { get; set; }
        public bool Discontiuned { get; set; }

        //Navigation Property
        public Category Category { get; set; }
    }
}
