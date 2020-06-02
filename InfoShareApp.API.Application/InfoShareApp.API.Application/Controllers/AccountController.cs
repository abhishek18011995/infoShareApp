using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using InfoShareApp.API.Application.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoShareApp.API.Application.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private ILogger<AccountController> logger;

        public AccountController( ILogger<AccountController> logger)
        {
            this.logger = logger;
        }

        // POST api/<controller>
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Post([FromBody]string userName)
        {
            return Ok(new { baseUrl = this.HttpContext.User.Claims, apiUrl = "bbbb", loginUrl = "dsad" });
        }

        [AllowAnonymous]
        [HttpGet("login")]
        public IActionResult GetLogin()
        {
            return Ok(new { baseUrl = this.HttpContext.User.Claims, apiUrl = "bbbb", loginUrl = "dsad" });
        }
    }
}
