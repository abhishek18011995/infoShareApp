

namespace InfoShareApp.API.Application.Models
{
    public class ProductInfoDto
    {

        //public string ProductDetails { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public string BrandName { get; set; }

        public string Type { get; set; }

        public bool InStock { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }

        public PriceDto Price { get; set; }
    }
}
