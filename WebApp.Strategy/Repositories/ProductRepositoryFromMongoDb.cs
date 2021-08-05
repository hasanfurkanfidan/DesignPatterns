using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Strategy.Entities;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromMongoDb : IProductRepository
    {
        private readonly IMongoCollection<Product> _mongoCollection;
        public ProductRepositoryFromMongoDb(IConfiguration configuration)
        {
            var conString = configuration.GetConnectionString("MongoDb");
            var client = new MongoClient(conString);
            var database = client.GetDatabase("ProductDb");
            _mongoCollection = database.GetCollection<Product>("Products");
        }
        public async Task AddAsync(Product product)
        {
            await _mongoCollection.InsertOneAsync(product);
        }

        public async Task DeleteAsync(Product product)
        {
            await _mongoCollection.DeleteOneAsync(x=>x.Id==product.Id);
        }

        public async Task<List<Product>> GetAllByUserIdAsync(string userId)
        {
            return await _mongoCollection.Find(p => p.AppUserId == userId).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _mongoCollection.Find(p => p.AppUserId == id).SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            await _mongoCollection.ReplaceOneAsync(p => p.Id == product.Id, product);
        }
    }
}
