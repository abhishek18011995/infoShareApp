using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
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

        public async Task<Product> GetProductById(string productId)
        {
            var collectionName = infoShareDatabaseSettings.ProductCollection;
            var canBeParsed = ObjectId.TryParse(productId, out ObjectId id);
            //Product product = null;

            if (canBeParsed)
            {
                var filter = Builders<Product>.Filter.Eq(fil => fil.Id, productId);
              var  product = await mongoDbService.GetById<Product>(infoShareDatabaseSettings.ProductCollection, filter);

                if (product != null)
                {
                    return product;
                }
                else
                {
                    this.logger.LogError($"Product with id {productId} not found");
                    return default(Product);
                }
            } else
            {
                this.logger.LogError("product id is invalid/not found");
                return default(Product);
            }

        }
    }
}
