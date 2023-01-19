using BetService.BusinessLogic.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class OutcomeEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public CoefficientEntity Coefficient { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }
    }
}
