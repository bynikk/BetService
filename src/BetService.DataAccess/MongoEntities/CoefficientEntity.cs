using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using BetService.BusinessLogic.Enums;

namespace BetService.DataAccess.MongoEntities
{
    public class CoefficientEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Rate { get; set; }

        public CoefficientStatusType StatusType { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Amount { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public double Probability { get; set; }
    }
}
