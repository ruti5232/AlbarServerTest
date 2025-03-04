using DAL.Entities;

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
