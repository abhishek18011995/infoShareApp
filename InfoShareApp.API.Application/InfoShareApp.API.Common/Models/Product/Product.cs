using System;
using System.Collections.Generic;
using System.Text;

namespace InfoShareApp.API.Common.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string BrandName { get; set; }
        public string Type { get; set; }
        public bool InStock { get; set; }
        public Enums.GenderEnum Gender { get; set; }
        public ProductInfo ProductInfo { get; set; }
        public Price Price { get; set; }
    }
}
