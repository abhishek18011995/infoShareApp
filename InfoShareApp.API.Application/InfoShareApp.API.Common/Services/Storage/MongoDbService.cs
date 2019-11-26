using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Data.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public class MongoDbService: IMongoDbService
    {
        private readonly IMongoDatabase database;

        public MongoDbService(IInfoShareDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            database = client.GetDatabase(databaseSettings.DatabaseName);
        }

        public async Task<IEnumerable<T>> Get<T>(string collectionName)
        {
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            var result = await mongoCollection.FindAsync(collection => true);
            return result.ToList();
        }        
    }
}
