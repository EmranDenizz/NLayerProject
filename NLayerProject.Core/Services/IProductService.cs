using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService
    {
        Task<Product> GetWithCategoryByIdAsync(int productId); //Gelen id bilgisine göre ürünü ve ürünün yer aldığı kategory bilgisini döner.
    }
}
