﻿using System.Collections.Generic;
using System.Threading.Tasks;
using InfoShareApp.API.Application.Models;
using InfoShareApp.API.Application.Services;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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

        // GET: api/<controller>
        [HttpGet("search")]
        public async Task<IActionResult> SearchProduct([FromQuery]string q)
        {
            var productList = await productService.SearchProduct(q);

            if (productList != null)
            {
                return Ok(productList);
            }
            else
            {
                //return Ok(new List<ProductDto>() { });
                return StatusCode(500, "Some error occured while processing your request");
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var product = await productService.GetProductById(id);

            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound($"Product with id '{id}' not found");
            }
        }

    }
}
