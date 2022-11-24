using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FakeData_CodeFirst.Models.Context
{
    public class MyContext : DbContext   // Veri tabanı işlemleri için DbContext classından miras alırız.
    {
        public MyContext()
        {
            Database.SetInitializer(new VeritabaniOlusturucu());   // VeritabaniOlusturucu classına bak. Bu classın miras aldığı class a göre bu Initializer i çalıştır. Yani veri tabanı yoksa çalışan bir class set ettik, veri tabanının ilk ayağa kaltığı ana(constructr a)
        }

        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }

    }




    // Bu seçim Varsayılan olarak gelen başlatıcıdır. Adındanda anlaşılacağı üzere daha önce veritabanı oluşturulmadıysa, yeni veritabanı / tablo oluşturulacaktır, eğer daha önce DbContext’te veritabanını veya tabloyu oluşturduysanız işleminizi yapmıyacak, hata verecektir.
    public class VeritabaniOlusturucu : CreateDatabaseIfNotExists<MyContext>  
    {
        protected override void Seed(MyContext context)   // Database oluştuktan sonra örnek data oluşturmak için Seed metodunu kullandık. Manage Nuget Packages den FakeData kütüphaneini ekliyoruz. 
        {
            // Kişiler insert ediliyor
            for (int i = 0; i < 10; i++)
            {
                Kisiler kisi = new Kisiler();
                kisi.Ad = FakeData.NameData.GetFirstName();
                kisi.Soyad = FakeData.NameData.GetSurname();
                kisi.Yas = FakeData.NumberData.GetNumber(10, 90);

                context.Kisiler.Add(kisi);
            }

            context.SaveChanges();

            // Adreler insert ediliyor
            List<Kisiler> tumKisiler = context.Kisiler.ToList();
            
            foreach (Kisiler kisi in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,5); i++)
                {
                    Adresler adres = new Adresler();
                    adres.AdresTanim = FakeData.PlaceData.GetAddress();
                    adres.Kisi = kisi;

                    context.Adresler.Add(adres);
                }

            }

            context.SaveChanges();
        }
    }
}