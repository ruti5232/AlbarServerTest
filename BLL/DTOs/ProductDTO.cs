

namespace BLL.DTOs
{
    public class ProductDTO
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public double? Price { get; set; }
        public int? UnitsInStock { get; set; }
    }
}
