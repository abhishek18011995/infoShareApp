using InfoShareApp.API.Common.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public interface IMongoDbService
    {
        Task<List<T>> Get<T>(string collectionName);

        Task<T> GetById<T>(string collectionName, FilterDefinition<T> filterDefinition);

        Task<T> Create<T>(string collectionName, FilterDefinition<T> filterDefinition, UpdateDefinition<T> updateDefinition, FindOneAndUpdateOptions<T> options);
    }
}
