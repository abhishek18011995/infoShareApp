using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Repository
{
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IMongoDbService mongoDbService;
        private readonly IInfoShareDatabaseSettings infoShareDatabaseSettings;
        private readonly ILogger<ContactUsRepository> logger;

        public ContactUsRepository(IMongoDbService mongoDbService, IInfoShareDatabaseSettings infoShareDatabaseSettings, ILogger<ContactUsRepository> logger)
        {
            this.mongoDbService = mongoDbService;
            this.infoShareDatabaseSettings = infoShareDatabaseSettings;
            this.logger = logger;
        }

        public async Task<ContactUs> RaiseNewQuery(ContactUs contactUs)
        {
            var filter = Builders<ContactUs>.Filter.Eq(fil => fil.Email , contactUs.Email);
            var update = Builders<ContactUs>.Update.Push<ContactUsQuery>(s => s.Query, contactUs.Query.FirstOrDefault());
            var options = new FindOneAndUpdateOptions<ContactUs> { IsUpsert = true, ReturnDocument = ReturnDocument.After };

            ContactUs result = await mongoDbService.Create<ContactUs>(this.infoShareDatabaseSettings.ContactUsCollection, filter, update, options);

            if (result != null)
            {
                return result;
            }
            else
            {
                this.logger.LogError("Some error occuured raising new query failed");
                return default(ContactUs);
            }
        }
    }
}
