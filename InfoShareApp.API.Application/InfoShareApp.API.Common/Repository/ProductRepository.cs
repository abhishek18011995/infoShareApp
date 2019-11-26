using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoDbService mongoDbService;
        private readonly IInfoShareDatabaseSettings infoShareDatabaseSettings;

        public ProductRepository( IInfoShareDatabaseSettings infoShareDatabaseSettings, IMongoDbService mongoDbService)
        {
            this.mongoDbService = mongoDbService;
            this.infoShareDatabaseSettings = infoShareDatabaseSettings;
        }

        public async Task<List<Product>> GetProducts()
        {
            var collectionName = infoShareDatabaseSettings.ProductCollection;

            return await mongoDbService.Get<Product>(infoShareDatabaseSettings.ProductCollection);
        }
    }
}
