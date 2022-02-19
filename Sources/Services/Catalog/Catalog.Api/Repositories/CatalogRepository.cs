using Catalog.Api.DataContext;
using Catalog.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Catalog.Api.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        ICatalogContext context = null;
        public CatalogRepository(ICatalogContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }        

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            return await context.Products.Find(p=>true).ToListAsync();
        }

        public async Task<IReadOnlyList<Product>> GetAsync(Expression<Func<Product, bool>> predicate)
        {
            return await context.Products.Find(predicate).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await context.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        }
       
        public async Task AddAsync(Product entity)
        {
            await context.Products.InsertOneAsync(entity);
        }

        public async Task<bool> DeleteAsync(Product entity)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Id == entity.Id);

            var result = await context.Products.DeleteOneAsync(filter);

            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<bool> UpdateAsync(Product entity)
        {
            var filter = Builders<Product>.Filter.Where(p => p.Id == entity.Id);

            var result = await context.Products.ReplaceOneAsync(filter,entity);

            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
    }
}
