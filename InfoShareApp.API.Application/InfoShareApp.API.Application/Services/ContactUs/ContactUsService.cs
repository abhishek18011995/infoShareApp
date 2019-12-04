using AutoMapper;
using InfoShareApp.API.Application.Models;
using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace InfoShareApp.API.Application.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IContactUsRepository contactUsRepository;
        private readonly ILogger<ContactUsService> logger;
        private readonly IMapper mapper;

        public ContactUsService(IContactUsRepository contactUsRepository, ILogger<ContactUsService> logger, IMapper mapper)
        {
            this.contactUsRepository = contactUsRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        public async Task<ContactUsDto> RaiseNewQuery(ContactUsDto contactUs)
        {
            var mappedResult = this.mapper.Map<ContactUs>(contactUs);

            try
            {
                var result = await this.contactUsRepository.RaiseNewQuery(mappedResult);
                if (result != null)
                {
                    return this.mapper.Map<ContactUs, ContactUsDto>(result);
                }
                return null;
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Some error occured while raising a new query");
                return null;
            }

        }
    }
}
