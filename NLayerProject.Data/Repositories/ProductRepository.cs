using Microsoft.EntityFrameworkCore;
using NLayerProject.Core;
using NLayerProject.Core.Repository;
using NLayerProject.Data.Connection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public ProductRepository(DbContext context) : base(context)
        {
            //Kalıtım aldığımız sınıfta Constructor tanımımız var. O yüzden o sınıfı kalıtım alan sınıflarda
            //Constructor tanımlaması olmak zorundadır.DbContext nesnemizi base sınıfına kalıtım aldığımız Repository sınıfı
            //içerindeki Constructor içerisine gönderiyoruz.
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            //Include metodu ile ürüne ait kategori bilgisini de Products tablom içerisine eklemiş olacağım.
            return await appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}
