using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId); //Gelen id bilgisine göre ürünü ve ürünün yer aldığı kategory bilgisini döner.
    }
}
