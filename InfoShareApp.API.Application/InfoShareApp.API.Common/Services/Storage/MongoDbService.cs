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
        private readonly IMongoCollection<Product> mongoCollection;
        public MongoDbService(IInfoShareDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            database = client.GetDatabase(databaseSettings.DatabaseName);
            mongoCollection = database.GetCollection<Product>("Product");
        }

        //public List<T> Get<T>(string collectionName)
        //{
        //    List<T> result;
        //    IMongoCollection<T>  mongoCollection = database.GetCollection<T>(collectionName);
        //    result = mongoCollection.Find(collection => true).ToList();
        //    //result = mongoCollection.FindAsync(collection => true);
        //    return result;
        //}

        public async Task<List<T>> Get<T>(string collectionName)
        {
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            var result = await mongoCollection.FindAsync(collection => true);
            //result = mongoCollection.FindAsync(collection => true);
            return result.ToList();
        }


        //public List<Product> Get(string collectionName)
        //{
        //    List<Product> result;
        //    result = _product.Find(collection => true).ToList();
        //    return result;
        //}
    }
}
