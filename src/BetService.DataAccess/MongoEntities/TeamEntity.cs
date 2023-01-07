using BetService.BusinessLogic.Enums;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class TeamEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        public CompetitionType CompetitionType { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string logo_img { get; set; }
    }
}
