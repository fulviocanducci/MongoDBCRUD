using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBCRUD.Entities
{    
    public class News
    {
        public News()
        {
        }

        [BsonId()]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        [BsonRequired()]
        public string Title { get; set; }

        [BsonElement("body")]
        [BsonRequired()]
        public string Body { get; set; }

        [BsonElement("created")]
        [BsonRequired()]
        public DateTime Created { get; set; }

        [BsonElement("active")]
        [BsonRequired()]
        public bool Active { get; set; }
    }
}
