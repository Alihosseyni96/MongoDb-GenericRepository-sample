using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_Sample.Models
{
    public class Customer
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("FirstName")]

        public string FName { get; set; }

        [BsonElement("LastName")]

        public string LName { get; set; }

        [BsonElement("Age")]

        public int Age { get; set; }

    }
}
