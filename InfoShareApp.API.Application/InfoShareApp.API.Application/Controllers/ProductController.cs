﻿using System.Threading.Tasks;
using InfoShareApp.API.Application.Models;
using InfoShareApp.API.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InfoShareApp.API.Application.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> GetProductList()
        {
            var productList = await productService.GetProducts();

            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                return StatusCode(500, "Some error occured while processing your request");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}