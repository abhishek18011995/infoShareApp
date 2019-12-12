using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AutoMapper;
using InfoShareApp.API.Application.Models;

namespace InfoShareApp.API.Application.Services
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
            this.mapper = mapper;
        }


        public async Task<List<ProductDto>> GetProducts()
        {
            try
            {
                var result = await productRepository.GetProducts();
                if (result != null)
                {
                    List<ProductDto> productList = this.mapper.Map<List<Product>, List<ProductDto>>(result);
                    return productList;
                }
                return null;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Some error occured while getting the product list");
                return null;
            }
        }

        public Task<List<ProductDto>> GetProduct(string id)
        {

            //try
            //{
            //    var result = await productRepository.GetProducts();
            //    if (result != null)
            //    {
            //        List<ProductDto> productList = this.mapper.Map<List<Product>, List<ProductDto>>(result);
            //        return productList;
            //    }
            //    return null;
            //}
            //catch (Exception ex)
            //{
            //    this.logger.LogError(ex, "Some error occured while getting the product list");
            //    return null;
            //}
        }
    }
}
