using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc.Grid.Models.Manager
{
    public class DatabaseContext:DbContext //veritabanı bağlantısı
    {
        public DbSet<Personel> Personeller  { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }
        public DbSet<Adres> Adresler { get; set; }
        public DatabaseContext() //DbCreate sınıfımız kullanan constructor
        {
            Database.SetInitializer<DatabaseContext>(new DbCreate());
        }
    }
    public class DbCreate:CreateDatabaseIfNotExists<DatabaseContext>//database oluşmadıysa oluşturmak için
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Ulke> ulkeList = new List<Ulke>();
            for (int i = 0; i < 10; i++) //10 tane ülke oluşturmak için
            {
                Ulke ulke = new Ulke();
                ulke.Ad = FakeData.PlaceData.GetCounty();//fake data ile ulke nesnesine random bir ülke atadık
                ulkeList.Add(ulke);//random ülkeyi ulkeList içine ekledik
                context.Ulkeler.Add(ulke);//random ülkeyi contexte ekledik
            }
            context.SaveChanges();//db kaydet

            for (int i = 0; i < 100; i++) //100 tane personel oluşturmak için
            {
                Personel per = new Personel();
                per.Ad = FakeData.NameData.GetFirstName();
                per.Soyad = FakeData.NameData.GetSurname();
                per.Yas = FakeData.NumberData.GetNumber(10,90);

                //personele oluşturduğumuz rastgele ülkelerden birini atamak için
                Random r = new Random();
                int deger = r.Next(0,10);

                per.Ulke = ulkeList[deger];

                context.Personeller.Add(per);

            }
            context.SaveChanges();
        }
    }
}