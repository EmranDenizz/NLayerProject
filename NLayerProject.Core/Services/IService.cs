using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        //Neden Generic Repository varken aynı kodları içeren bir Servis yazıyorum?
        //Çünkü servisimiz sabit kalır.İlerleyen süreçte veritabanı altyapısını(sql'den oracle'ye geçmek gibi) değiştirmemiz grekebilir.
        //Bu durumla karşılaşırsak tek yapmamız gereken sadece Repository'lerimizi değiştirmemiz.Servisimiz aynı kalır.
        //Önemli:Projemiz direk Repository'lerim ile haberleşmeelidir.Ayrı bir interface(servis) üzerinden haberleşmeliyiz.
        //Repository ile Servis ar. farklardan biri:Repository sadece db işlemleri yapar.Servis ise db içi ve dışı metotlar tanımlanabilir.
        //Modele özgü farklı metotlar servis içinde yazılmalıdır.
        Task<TEntity> GetByIdAsync(int id); //Gelen id numarasına göre ilgili kaydı bulur
        Task<IEnumerable<TEntity>> GetAllAsync(); //İstenilen modeldeki tüm verileri çeker
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate); // "Expression" karşılık lambda bir ifade gelicek. Örnek:x>=x.Id=23 gibi 23 id'li kullanıcı varsa true, yoksa false.Bool tip onu ifade ediyor.
        Task<TEntity> SingleOrDefaultaSync(Expression<Func<TEntity, bool>> predicate); //TEntitiy yerine karşılık gelen modelden istenilen bilgi aranıyor.Varsa boool ile hafızaya alınıyor.
        Task AddAsync(TEntity entity); //Bir model eklenirse kullanılır.
        Task AddRangeAsync(IEnumerable<TEntity> entities); //Birden fazla model eklenirse kullanılacak.
        void Remove(TEntity entity); //Tek kayıt silmek için kullanılır.
        void RemoveRange(IEnumerable<TEntity> entities); //Birden fazla kayıt silmek için kullanılır.
        TEntity Update(TEntity entity); //Güncelleme için kullanılır.
    }
}
