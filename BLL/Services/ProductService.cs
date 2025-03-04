using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;


namespace BLL.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ILogService _logService;
        public ProductService(IProductRepository productRepository, IMapper mapper, ILogService logService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logService = logService;
        }
        public async Task<ProductDTO> AddAsync(ProductDTO productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                var addedProduct = await _productRepository.AddAsync(product);
                return _mapper.Map<ProductDTO>(addedProduct);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync("Error in Add Product", ex);
                throw;
            }
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            try
            {
                var products = await _productRepository.GetAllAsync();
                return _mapper.Map<List<ProductDTO>>(products);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync("Error in GetAllProducts", ex);
                throw;
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            try
            {
                var product = await _productRepository.GetById(id);
                return _mapper.Map<ProductDTO>(product);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync($"Error in GetProductById - Id: {id}", ex);
                throw;
            }
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                var updatedProduct = await _productRepository.UpdateAsync(product);
                return _mapper.Map<ProductDTO>(updatedProduct);
            }
            catch (Exception ex)
            {
                await _logService.LogErrorAsync("Error in UpdateProduct", ex);
                throw;
            }
        }
    }
}
