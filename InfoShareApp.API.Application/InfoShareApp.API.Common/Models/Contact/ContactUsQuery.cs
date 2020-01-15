using MongoDB.Bson.Serialization.Attributes;
using System;

namespace InfoShareApp.API.Common.Models
{
    public class ContactUsQuery
    {
        //[BsonElement(elementName: "name")]
        //public string Name { get; set; }

        [BsonElement(elementName: "subject")]
        public string Subject { get; set; }

        [BsonElement(elementName: "message")]
        public string Message { get; set; }

        [BsonElement(elementName: "submitDate")]
        public DateTime SubmitDate { get; set; }
    }
}
