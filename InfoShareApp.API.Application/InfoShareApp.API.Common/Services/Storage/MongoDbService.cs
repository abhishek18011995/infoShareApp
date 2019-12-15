using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public class MongoDbService : IMongoDbService
    {
        private readonly IMongoDatabase database;
        private readonly ILogger<MongoDbService> logger;

        public MongoDbService(IInfoShareDatabaseSettings databaseSettings, ILogger<MongoDbService> logger)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            database = client.GetDatabase(databaseSettings.DatabaseName);
            this.logger = logger;
        }

        public async Task<List<T>> Get<T>(string collectionName)
        {
            IAsyncCursor<T> result;
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            try
            {
                result = await mongoCollection.FindAsync(collection => true);
                return result.ToList();
            }
            //catch (MongoWaitQueueFullException ex)
            //{
            //    this.logger.LogError(ex, ex.Message);
            //    await Task.Delay(1000);
            //}
            catch (MongoException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return default(List<T>);
            }
        }

        public async Task<T> GetById<T>(string collectionName, FilterDefinition<T> filterDefinition)
        {
            IAsyncCursor<T> result;
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            try
            {
                result = await mongoCollection.FindAsync(filterDefinition);
                return result.FirstOrDefault();
            }
            catch (MongoException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return default(T);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.Message);
                return default(T);
            }
        }

        public async Task<T> Create<T>(string collectionName, FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition, FindOneAndUpdateOptions<T> options)
        {
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            try
            {
                //await mongoCollection.InsertOneAsync(item);
                var updatedResult = await mongoCollection.FindOneAndUpdateAsync(filterDefinition, updateDefinition, options);
                return updatedResult;
            }
            catch (MongoException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return default(T); ;
            }
        }
    }
}
