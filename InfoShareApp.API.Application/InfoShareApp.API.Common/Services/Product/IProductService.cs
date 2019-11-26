using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShareApp.API.Common.Models;

namespace InfoShareApp.API.Common.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProducts();
    }
}
