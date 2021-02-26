using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)  //Constructor
        {
            _dbContext = context;  //"_dbContext" ile veritabanına erişilir.
            _dbSet = context.Set<TEntity>(); // "_dbSet" ile gelen entity hangi modelse onun tablosuna gideriz.
        }
        public async Task AddAsync(TEntity entity) //Bir model eklenirse kullanılan metot
        {
            //Asenkron programlamada "async ve await" anahtar kelimeleri birlikte kullanılır.
            //"await" anahtar kelimesi ilgili metot bitene kadar await kullanılan satırda beklenilmesini sağlar.
            //Yeni model = Veritabanında yeni tablo
            await _dbSet.AddAsync(entity); //await olduğu için burası bitmeden yeni metota geçilemez.
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)//Birden fazla model eklenirse kullanılacak.
        {
            //Task neden kullanılır? Cevap : Asenkron programlamada geriye bir şey döndürmüyorsak "Task" anahtar kelimesi kullanılır. Senkron prog. "Void" kelimesine eşdeğerdir.
            await _dbSet.AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate) //Burada özel bir durum var. Geriye bana değer döndürecek.
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync() //İstenilen modeldeki tüm verileri çeker
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultaSync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
