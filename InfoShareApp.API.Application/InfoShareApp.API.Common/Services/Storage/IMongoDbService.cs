using InfoShareApp.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public interface IMongoDbService
    {
        //List<Product> Get(string collectionName);
        Task<List<T>> Get<T>(string collectionName);
        //List<T> Get<T>(string collectionName);
    }
}
