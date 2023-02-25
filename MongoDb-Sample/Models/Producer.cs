using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_Sample.Models
{
    public class Producer
    {
        [BsonId]

        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime CreateOn { get; set; }
        public string SalerName { get; set; }
    }
}
