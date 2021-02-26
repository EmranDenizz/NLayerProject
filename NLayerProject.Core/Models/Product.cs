using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Core
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public virtual Category Category { get; set; }  //Product modeli,nesnesi,tablosu ne derseniz diyin Category modeline bağlı olacağından sol yandaki kod satırı yazılır
        //"Virtual" anahtar kelimesi kullanma sebebimiz EF(Entity Framework) Category modeli üze. tracking(izleme) yapabilsin.Yani Category modeli üze. her bir değişikliği izleyebilsin.

    }
}
