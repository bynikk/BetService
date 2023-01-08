using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class OutcomeEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public OutcomeType OutcomeType { get; set; }

        public OutcomeStatusType StatusType { get; set; }

        public Coefficient[] Coefficients { get; set; }
    }
}
