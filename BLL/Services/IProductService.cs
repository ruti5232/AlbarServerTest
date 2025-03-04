using BLL.DTOs;


namespace BLL.Services
{
    public interface IProductService
    {
        Task<ProductDTO> AddAsync(ProductDTO productDto);

        Task<ProductDTO> UpdateAsync(ProductDTO productDto);

        Task<List<ProductDTO>> GetAllAsync();

        Task<ProductDTO> GetByIdAsync(int id);
    }
}
