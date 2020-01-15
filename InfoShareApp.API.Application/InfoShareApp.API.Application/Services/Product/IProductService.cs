using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShareApp.API.Application.Models;

namespace InfoShareApp.API.Application.Services
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();

        Task<ProductInfoDto> GetProductById(string id);

        Task<List<ProductDto>> SearchProduct(string text);
    }
}
