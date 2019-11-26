using InfoShareApp.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Services.Storage
{
    public interface IMongoDbService
    {
        Task<IEnumerable<T>> Get<T>(string collectionName);
    }
}
