using BetService.BusinessLogic.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities.CompetitionEntities
{
    public abstract class CompetitionEntityBase
    {
        public CompetitionEntityBase()
        {
            OutcomeGroupIds = Array.Empty<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public CompetitionType CompetitionType { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartTime { get; set; }

        public string[] OutcomeGroupIds { get; set; }
    }
}
