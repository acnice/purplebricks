using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PurpleBricksLibrary
{
    /// <summary>
    /// Holds property address details
    /// </summary>
    public class PropertyAddress
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        [BsonElement("streetAddress")]
        public string StreetAddress { get; set; }

        [BsonElement("suburb")]
        public string Suburb { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("postcode")]
        public string Postcode { get; set; }

        [BsonElement("verifiedAddress")]
        public bool VerifiedAddress { get; set; }
    }
}
