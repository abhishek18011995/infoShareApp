using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoDbService mongoDbService;
        private readonly IInfoShareDatabaseSettings infoShareDatabaseSettings;
        private readonly ILogger<ProductRepository> logger;

        public ProductRepository(IInfoShareDatabaseSettings infoShareDatabaseSettings, IMongoDbService mongoDbService, ILogger<ProductRepository> logger)
        {
            this.mongoDbService = mongoDbService;
            this.infoShareDatabaseSettings = infoShareDatabaseSettings;
            this.logger = logger;
        }

        public async Task<List<Product>> GetProducts()
        {
            var collectionName = infoShareDatabaseSettings.ProductCollection;
            var productList = await mongoDbService.Get<Product>(infoShareDatabaseSettings.ProductCollection);

            if (productList != null)
            {
                return productList;
            }
            else
            {
                this.logger.LogError("Some error occuured couldn't get the product list");
                return default(List<Product>);
            }

        }
    }
}
