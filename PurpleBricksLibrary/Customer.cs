using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PurpleBricksLibrary
{
    /// <summary>
    /// Holds customer details
    /// </summary>
    public class Customer
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("phoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }
    }
}
