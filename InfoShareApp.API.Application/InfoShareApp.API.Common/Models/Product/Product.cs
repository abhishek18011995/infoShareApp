using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InfoShareApp.API.Common.Models
{
    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement(elementName: "name")]
        public string Name { get; set; }

        [BsonElement(elementName: "imagePath")]
        public string ImagePath { get; set; }

        [BsonElement(elementName: "brandName")]
        public string BrandName { get; set; }

        [BsonElement(elementName: "type")]
        public string Type { get; set; }

        [BsonElement(elementName: "inStock")]
        public bool InStock { get; set; }

        [BsonElement(elementName: "gender")]
        public string Gender { get; set; }

        [BsonElement(elementName: "productInfo")]
        public ProductInfo ProductInfo { get; set; }

        [BsonElement(elementName: "price")]
        public Price Price { get; set; }
    }
}
