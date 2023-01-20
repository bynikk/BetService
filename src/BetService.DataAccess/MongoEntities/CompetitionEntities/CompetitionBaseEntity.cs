using BetService.BusinessLogic.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities.CompetitionEntities
{
    public abstract class CompetitionEntityBase
    {
        public CompetitionEntityBase()
        {
            OutcomeGroups = Array.Empty<OutcomeGroupEntity>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public CompetitionStatusType StatusType { get; set; }

        public CompetitionType Type { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartTime { get; set; }

        public OutcomeGroupEntity[] OutcomeGroups { get; set; }
    }
}
