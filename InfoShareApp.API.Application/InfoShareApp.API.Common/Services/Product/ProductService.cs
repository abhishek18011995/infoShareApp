using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;

namespace InfoShareApp.API.Common.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger<ProductService> logger;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, ILogger<ProductService> logger, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                //List<ProductDto> productList
                //var productList = new ProductDto() { };
                return await productRepository.GetProducts();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Some error occured while getting the product list");
                return null;
            }
        }
    }
}
