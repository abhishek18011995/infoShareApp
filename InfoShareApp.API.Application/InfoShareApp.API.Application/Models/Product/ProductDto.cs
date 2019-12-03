

namespace InfoShareApp.API.Application.Models
{
    public class ProductDto
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string ImagePath { get; set; }
        
        public string BrandName { get; set; }
        
        public string Type { get; set; }
        
        public bool InStock { get; set; }
        
        public string Gender { get; set; }
        
        public ProductInfoDto ProductInfo { get; set; }
        
        public PriceDto Price { get; set; }
    }
}
