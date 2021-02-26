using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerProject.Data.Seeds
{
    public class ProductSeed:IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;  //Buradan kategoryId'ler gelicek.
        public ProductSeed(int[] ids) //_ids değişkeni bu constructor içinde doldurulacak.
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, Name = "Pilot Kalem", Price = 12.00, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 2, Name = "Kurşun Kalem", Price = 12.00, Stock = 150, CategoryId = _ids[0] },
                new Product { Id = 3, Name = "Tükenmez Kalem", Price = 12.00, Stock = 100, CategoryId = _ids[0] },
                new Product { Id = 4, Name = "Kareli Defter", Price = 12.00, Stock = 100, CategoryId = _ids[1] },
                new Product { Id = 5, Name = "Çizgili Defter", Price = 12.00, Stock = 100, CategoryId = _ids[1] });
        }
    }
}
