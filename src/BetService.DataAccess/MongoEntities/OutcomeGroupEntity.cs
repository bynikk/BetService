using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class OutcomeGroupEntity
    {
        public OutcomeGroupEntity()
        {
            Outcomes = Array.Empty<OutcomeEntity>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        public OutcomeGroupType Type { get; set; }

        public OutcomeEntity[] Outcomes { get; set; }
    }
}
