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

        public async Task<List<T>> Get<T>(string collectionName, FilterDefinition<T> filterDefinition = null, FindOptions<T> options = null)
        {
            IAsyncCursor<T> result;
            IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);
            //mongoCollection.Indexes.CreateOne(Builders<T>.IndexKeys.Text(x => x.subject));
            //var indexes = mongoCollection.Indexes.ListAsync().Result;

            if (filterDefinition == null)
            {
                filterDefinition = FilterDefinition<T>.Empty;
            }
            try
            {
                result = await mongoCollection.FindAsync(filterDefinition, options);
                return result.ToList();
            }
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
                var updatedResult = await mongoCollection.FindOneAndUpdateAsync(filterDefinition, updateDefinition, options);
                return updatedResult;
            }
            catch (MongoException ex)
            {
                this.logger.LogError(ex, ex.Message);
                return default(T);
            }
        }

        //public async Task<List<T>> Search<T>(string collectionName, FilterDefinition<T> filterDefinition, FindOptions<T> options = null)
        //{
        //    IAsyncCursor<T> result;
        //    IMongoCollection<T> mongoCollection = database.GetCollection<T>(collectionName);

        //    try
        //    {
        //        result = await mongoCollection.FindAsync(filterDefinition);
        //        return result.ToList();
        //    }
        //    catch (MongoException ex)
        //    {
        //        this.logger.LogError(ex, ex.Message);
        //        return default(List<T>);
        //    }
        //}
    }
}
