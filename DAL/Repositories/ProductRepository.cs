using DAL.Data;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogRepository _logRepository;
        public ProductRepository(AppDbContext appDbContext, ILogRepository logRepository)
        {
            _appDbContext = appDbContext;
            _logRepository = logRepository;
        }
        public async Task<Product> AddAsync(Product product)
        {
            try
            {
                var res = await _appDbContext.Products.AddAsync(product);
                await SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error adding product", ex);
                throw;
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
               return await _appDbContext.Products.AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error fetching all products", ex);
                throw;
            }

        }


        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _appDbContext.Products.FindAsync(id);
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error fetching product by ID", ex);
                throw;
            }

        }

        public async Task<Product> UpdateAsync(Product product)
        {
            try
            {
                var res = _appDbContext.Update(product);
                await SaveChangesAsync();
                return res.Entity;
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error updating product", ex);
                throw;
            }

        }
        private async Task SaveChangesAsync() {
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await _logRepository.LogErrorAsync("Error saving changes to the database", ex);
                throw;
            }
        } 

    }
}
