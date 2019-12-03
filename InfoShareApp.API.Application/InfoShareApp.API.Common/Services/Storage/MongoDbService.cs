﻿using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public class MongoDbService: IMongoDbService
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
            //List<T> result;
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
    }
}