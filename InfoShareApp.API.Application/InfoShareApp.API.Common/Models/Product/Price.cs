using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace InfoShareApp.API.Common.Models
{
    [BsonIgnoreExtraElements]
    public class Price
    {
        [BsonElement(elementName: "mrp")]
        public double MRP { get; set; }

        [BsonElement(elementName: "discountedPrice")]
        public double DiscountedPrice { get; set; }
    }
}
