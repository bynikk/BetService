using BetService.BusinessLogic.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class CompetitionEntity
    {
        public CompetitionEntity()
        {
            AvailableOutcomeIds = Array.Empty<string>();
            Teams = Array.Empty<string>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        public CompetitionType CompetitionType { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime StartTime { get; set; }

        public string[] Teams { get; set; }

        public string[] AvailableOutcomeIds { get; set; }
    }
}
