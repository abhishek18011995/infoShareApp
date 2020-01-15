using InfoShareApp.API.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoShareApp.API.Application.Services
{
    public interface IContactUsService
    {
        Task<ContactUsDto> RaiseNewQuery(ContactUsDto contactUs);
    }
}
