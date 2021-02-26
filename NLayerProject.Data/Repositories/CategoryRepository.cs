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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public CategoryRepository(DbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            await appDbContext.Categories.Include(x=>x.Id).SingleOrDefaultAsync(x=>x.)
        }
    }
}
