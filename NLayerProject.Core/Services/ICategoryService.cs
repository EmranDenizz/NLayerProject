using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface ICategoryService
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId); //Bu metot bir id değeri alacak. Sonra bu id numaralı kategori bilgisi ve bu kategoride bulunan ürünleri bize geri döndürecek.
        //Zaten repository oluşturmuştuk. Bu niye var diyorsanız, bazen modele,entitye özel sorgular olabilir. Zaten generic repository interface'ini kalıtım alıyoruz.
    }
}
