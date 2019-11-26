using MongoDB.Bson.Serialization.Attributes;

namespace InfoShareApp.API.Common.Models
{
    [BsonIgnoreExtraElements]
    public class ProductInfo
    {

        [BsonElement(elementName: "productDetails")]
        public string ProductDetails { get; set; }
    }
}
