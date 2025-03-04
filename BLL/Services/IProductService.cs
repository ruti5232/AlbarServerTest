using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
