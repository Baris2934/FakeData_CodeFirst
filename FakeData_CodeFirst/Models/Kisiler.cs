using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FakeData_CodeFirst.Models
{
    [Table("Kisiler")]  // Tablomuza isim verdik.
    public class Kisiler
    { 
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // ID'nin primary key olduğunu belirttik. Identity, otomatik artan olmasını belirttik.
        public int ID { get; set; }

        [StringLength(20), Required]  // Karakter sınırı ve boş geçilemez olduğunu belirttik.
        public string Ad { get; set; }

        [StringLength(20), Required]
        public string Soyad { get; set; }

        [Required]
        public int Yas { get; set; }

        public virtual List<Adresler> Adresler { get; set; }
    }
}