using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NLayerProject.Core
{
    public class Category //internal class = tanımlandığı katmanda,namespace alanında tüm class ve metotlarda erişilebilir.Farklı katmanlarda erişilemez.
    {
        public Category()  //Constructor(Kurucu metot)
        {
            //İlgili kategori için bir ürün oluşturulduğu an bellekte bir alan yaratmak için kullanıyoruz. Collection bir dizi yaratır.Referansını ise ICollection interface'inden alır.
            Products = new Collection<Product>(); 
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } //Silindi mi silinmedi mi bilgisini tutacağız
        public ICollection<Product> Products { get; set; } //Bir kategori içinde birden fazla ürün yer alabileceğinden dolayı "ICollection" kullanılır.Bu bir dizi yaratır.
    }
}
