using BetService.BusinessLogic.Enums;
using BetService.BusinessLogic.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace BetService.DataAccess.MongoEntities
{
    public class CoefficientGroupEntity
    {
        public CoefficientGroupEntity()
        {
            Coefficients = Array.Empty<CoefficientEntity>();
        }

        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        public CoefficientGroupType Type { get; set; }

        public CoefficientEntity[] Coefficients { get; set; }
    }
}
