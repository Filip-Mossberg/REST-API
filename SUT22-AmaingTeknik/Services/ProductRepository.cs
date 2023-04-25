using AmazingTeknikModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SUT22_AmaingTeknik.Models;

namespace SUT22_AmaingTeknik.Services
{
    public class ProductRepository : IAmazingTeknik<Product>
    {
        private AppDbContext _appContext;
        public ProductRepository(AppDbContext appDbContext)
        {
            this._appContext = appDbContext;
        }

        // Säkerställa att vi får in datan så det inte kommer in som null
        public async Task<Product> Add(Product newEntity)
        {
            var result = await _appContext.Products.AddAsync(newEntity);
            await _appContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> Delete(int id)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
            if(result != null)
            {
                _appContext.Products.Remove(result);
                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _appContext.Products.ToListAsync();
        }

        public async Task<Product> GetSingle(int id)
        {
            return await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == id);
        }

        public async Task<Product> Update(Product entity)
        {
            var result = await _appContext.Products.FirstOrDefaultAsync(p => p.ProductID == entity.ProductID);
            if(result != null)
            {
                result.ProductName = entity.ProductName;
                result.Price = entity.Price;
                result.Category = entity.Category;

                await _appContext.SaveChangesAsync();
                return result;
            }
            return null;
        }
    }
}
