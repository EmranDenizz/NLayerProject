using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product> //Bu sınıfın bir yapılanadırma sınıfı olabilmesi için ilgili arayüzü kalıtım alması zorunludur.
    {
        //"Product" modelimiz veritabanında bir tablo olarak oluşacak. Bu tablonun primary key sütunu hangisi olacak, 
        //primary key değeri kaç kaç artacak vs düzenlemeler bu clasta yapılır ki DbContext sınıfımız şişmesin.Kod sayısı artmasın.
        //Bu sınıflar zorunlu değil ama best practices kurallarına göre yapılmalıdır.Yapılmazsa "DbContext" sınıfı içindeki
        //"OnModelCreating metotu içerisinde de bu düzenlemeler yapılabilir.
        public void Configure(EntityTypeBuilder<Product> builder)//builder üze. Product modelimizin veirtabanında nasıl oluşturulacağının düzenlemelerini yaparız. 
        {
            builder.HasKey(x => x.Id); //Id sütununu primary key yapar.
            builder.Property(x => x.Id).UseIdentityColumn(); //Id sütununun değerinin birer birer arttırır.
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200); //Name alanı mutlaka dolu olmalı ve max. uzunluk 200 olabilir.
            builder.Property(x => x.Stock).IsRequired();
            //Price(Fiyat) adlı sütunun veri tipi decimal olcak ve toplam 10 basamaklı ve 2 basamağı nokta'dan sonra yazacak
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);
            builder.ToTable("Products"); // Tablo adını vermiş olduk
        }
    }
}
