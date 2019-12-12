using AutoMapper;
using InfoShareApp.API.Application.Models;
using InfoShareApp.API.Common.Models;
using InfoShareApp.API.Common.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ContactUsDto> RaiseNewQuery(ContactUsDto contactUsFormBody)
        {

            try
            {
                ContactUs contactUs = new ContactUs()
                {
                    Email = contactUsFormBody.Email,
                    Query = new List<ContactUsQuery>()
                    {
                        new ContactUsQuery()
                        {
                            Message = contactUsFormBody.Message,
                            Subject = contactUsFormBody.Subject,
                            SubmitDate = DateTime.Now
                        }
                    }
                };
                var dbResult = await this.contactUsRepository.RaiseNewQuery(contactUs);
                if (dbResult != null)
                {
                    var result = new ContactUsDto()
                    {
                        Email = dbResult.Email,
                        Message = dbResult.Query.First().Message,
                        Subject = dbResult.Query.First().Subject
                    };
                    return result;
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
