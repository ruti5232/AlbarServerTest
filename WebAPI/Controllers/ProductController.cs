using Azure.Core;
using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetByIdAsync(int id)
        {
            var data = await _productService.GetByIdAsync(id);
            return Ok(data);
        }
        [HttpGet]
        [Route("GetProducts")]
        [Authorize]
        public async Task<ActionResult<List<ProductDTO>>> GetAllAsync()
        {
            var data = await _productService.GetAllAsync();
            return Ok(data);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> AddAsync([FromBody] ProductDTO productDto)
        {
            var data = await _productService.AddAsync(productDto);
            return Ok(data);
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ProductDTO>> UpdateAsync([FromBody] ProductDTO productDto)
        {
            var data = await _productService.UpdateAsync(productDto);
            return Ok(data);
        }
    }
}
