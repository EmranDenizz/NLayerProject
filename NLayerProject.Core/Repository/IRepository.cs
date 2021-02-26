using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.Repository
{
    public interface IRepository<TEntity> where TEntity:class //"where TENtity:class" = Bu TEntity mutlaka bir sınıf olsun dedik.Bu kalıp zorunludur.
    {
        Task<TEntity> GetByIdAsync(int id); //Gelen id numarasına göre ilgili kaydı bulur
        Task<IEnumerable<TEntity>> GetAllAsync(); //İstenilen modeldeki tüm verileri çeker
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate); // "Expression" karşılık lambda bir ifade gelicek. Örnek:x=>x.Id=23 gibi 23 id'li kullanıcı varsa true, yoksa false.Bool tip onu ifade ediyor.
        Task<TEntity> SingleOrDefaultaSync(Expression<Func<TEntity, bool>> predicate); //TEntitiy yerine karşılık gelen modelden istenilen bilgi aranıyor.Varsa boool ile hafızaya alınıyor.
        Task AddAsync(TEntity entity); //Bir model eklenirse kullanılır.
        Task AddRangeAsync(IEnumerable<TEntity> entities); //Birden fazla model eklenirse kullanılacak.
        void Remove(TEntity entity); //Tek kayıt silmek için kullanılır.
        void RemoveRange(IEnumerable<TEntity> entities); //Birden fazla kayıt silmek için kullanılır.
        TEntity Update(TEntity entity); //Güncelleme için kullanılır.

    }
}
