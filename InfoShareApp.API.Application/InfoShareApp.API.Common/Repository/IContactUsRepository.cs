using InfoShareApp.API.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InfoShareApp.API.Common.Repository
{
    public interface IContactUsRepository
    {
        Task<ContactUs> RaiseNewQuery(ContactUs contactUs);
    }
}
