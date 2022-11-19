using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace temp_api.Models
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}
