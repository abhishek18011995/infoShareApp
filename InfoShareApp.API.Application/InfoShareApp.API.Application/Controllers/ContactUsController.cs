using InfoShareApp.API.Application.Models;
using InfoShareApp.API.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoShareApp.API.Application.Controllers
{
    [Route("api/[controller]")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsService contactUsService;
        private readonly ILogger<ContactUsController> logger;

        public ContactUsController(IContactUsService contactUsService, ILogger<ContactUsController> logger)
        {
            this.contactUsService = contactUsService;
            this.logger = logger;
        }

        // POST api/<controller>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ContactUsDto value)
        {
            if (!ModelState.IsValid) {
               foreach(var modelState in ModelState.Values)
                 {
                    foreach (ModelError error in modelState.Errors)
                    {
                        this.logger.LogError("Invalid request, {errorMessage}", error.ErrorMessage);
                    }
                }
                return BadRequest(ModelState);
            }

            var result = await this.contactUsService.RaiseNewQuery(value);
            if (result != null)
            {
                return NoContent();
            }
            return BadRequest("Some error occured while processing your request");
        }
    }
}
