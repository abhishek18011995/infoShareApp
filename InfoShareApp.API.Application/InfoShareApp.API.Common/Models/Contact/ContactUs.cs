using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace InfoShareApp.API.Common.Models
{
    public class ContactUs
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Email { get; set; }

        [BsonElement(elementName: "query")]
        public List<ContactUsQuery> Query { get; set; }
    }
}
