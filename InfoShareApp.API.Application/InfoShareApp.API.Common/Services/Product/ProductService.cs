using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Repository;

namespace InfoShareApp.API.Common.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task<List<Product>> GetProducts()
        //public string[] GetProducts()
        {
            //return new string[] { "value1", "value2" };
            return await productRepository.GetProducts();
        }
    }
}
