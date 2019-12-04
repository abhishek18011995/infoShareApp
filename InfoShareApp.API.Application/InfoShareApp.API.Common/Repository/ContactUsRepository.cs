using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Services.Storage;
using InfoShareApp.API.Data.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
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
            ContactUs result = await mongoDbService.Create<ContactUs>(this.infoShareDatabaseSettings.ContactUsCollection, contactUs);

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
