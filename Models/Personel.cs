using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc.Grid.Models
{
    [Table("Personeller")] //Veritabanındaki tablonun adı
    public class Personel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //primary key seçmek için ve otomatik artan
        public int Id{ get; set; }
        [StringLength(50),Required] //maks 50 karakter ve zorunlu alan
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }

        public Ulke Ulke{ get; set; } //Bir personelin 1 ülkesi olabilir, bunun için Ulke sınıfından property oluşturduk
    }
}