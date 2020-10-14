using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace backend.Models
{
    public class Client {

        [BsonId]
        public ObjectId Id { get; set; }
        public string Nit { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}