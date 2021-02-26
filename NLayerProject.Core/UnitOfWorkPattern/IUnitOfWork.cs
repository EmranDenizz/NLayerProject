using NLayerProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        //Veritabanında yapılacak düzenlemeler, güncelleştirmeler anlık değil, işlem tamamlanıca kaydedilir.
        //Örnek bir alışveriş yapalım.Bir ürün saatın alırken ödemeyi yaptığımız an veritabanına işlemler yansıtılır.
        //Ürünü sepete eklediğin an veritabanına gidip stoktan düşmek yerine satış işlemi yapılınca db güncellemesi yapılır.
        //Bu tasarım deseni bizi ciddi bir zaman ve maliyet külfetinden kurtarır.
        //Commit : Implement ettiğimiz zaman EF(Entity Framework) tarafında SaveChanges() metodunu çağıracak.   
        IProductRepository products { get; } //Best pratices için önerilen bu tarzda bunları burada tanımlamak.Ama tanımlamak zorunlu değil.
        ICategoryRepository categories { get; }
        Task CommitAsync(); //Asenkron metot
        void Commit(); //Senkron metot
    }
}
