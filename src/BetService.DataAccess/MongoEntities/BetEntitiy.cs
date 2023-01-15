using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    /// <summary>Database entity which represent bet abstraction model on data access layer.</summary>
    public class BetEntitiy
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string ProfileId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string OutcomeId { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string CoefficientId { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rate { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Amount { get; set; }
    }
}
