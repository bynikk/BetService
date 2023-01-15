using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities.CompetitionEntities
{
    public class CompetitionCSEntity : CompetitionEntityBase
    {
        [BsonRepresentation(BsonType.String)]
        public string Team1Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Team2Id { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int Team1KillAmount { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int Team2KillAmount { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime TotalTime { get; set; }
    }
}
