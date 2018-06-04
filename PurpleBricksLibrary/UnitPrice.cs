using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Globalization;

namespace PurpleBricksLibrary
{
    /// <summary>
    /// Indicates the board size: small or large
    /// </summary>
    public enum BoardSize
    {
        Small,
        Large
    }

    /// <summary>
    /// Holds details of board prices for a given period
    /// </summary>
    public class UnitPrice
    {
        #region Properties
        //[BsonId(IdGenerator = typeof(CombGuidGenerator))]
        //public Guid Id { get; set; }
        [BsonId]
        public ObjectId InternalId { get; set; }

        [BsonElement("price")]
        public decimal Price { get; set; }

        [BsonElement("size")]
        public BoardSize BSize { get; set; }

        [BsonElement("state")]
        public string State { get; set; }

        [BsonElement("effectFrom")]
        public string StrEffectFrom { get; set; }

        [BsonElement("effectTo")]
        public string StrEffectTo { get; set; }

        public DateTime? GetEffectFrom()
        {
            DateTime _date;
            if(DateTime.TryParseExact(StrEffectFrom, "dd/mm/yyyy", null, System.Globalization.DateTimeStyles.None, out _date))
            {
                return _date;
            }
            return null;
        }

        public DateTime? GetEffectTo()
        {
            DateTime _date;
            if (DateTime.TryParseExact(StrEffectTo, "dd/mm/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _date))
            {
                return _date;
            }
            return null;
        }
        #endregion
    }
}
