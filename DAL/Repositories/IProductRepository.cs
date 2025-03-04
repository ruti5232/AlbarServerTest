using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<List<Product>> GetAllAsync();

        Task<Product> GetById(int id);
    }
}
