using InfoShareApp.API.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();

        Task<Product> GetProductById(string productId);
    }
}
