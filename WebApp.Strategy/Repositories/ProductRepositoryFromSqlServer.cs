using BaseProject.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Strategy.Entities;

namespace WebApp.Strategy.Repositories
{
    public class ProductRepositoryFromSqlServer : IProductRepository
    {
        private readonly Context _context;
        public ProductRepositoryFromSqlServer(Context context)
        {
            _context = context;
        }
        public async Task AddAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllByUserIdAsync(string userId)
        {
            return await _context.Set<Product>().Where(p => p.AppUserId == userId).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(string id)
        {
            return await _context.Set<Product>().Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
