using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc.Grid.Models
{
    [Table("Ülkeler")]//Veritabanındaki tablonun adı
    public class Ulke
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)] //primary key seçmek için ve otomatik artan
        public int Id { get; set; }
        public string Ad{ get; set; }

        public List<Personel> Personeller { get; set; } //Bir ülkeye ait birden fazla personel olabilir o yüzden list şeklinde Personel sınıfından property oluşturduk
    }
}