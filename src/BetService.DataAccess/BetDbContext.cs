using BetService.DataAccess.MongoEntities;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BetService.DataAccess
{
    public class BetDbContext
    {
        private readonly IMongoDatabase _context;
        private readonly BetDbConfig _betDbConfig;

        public BetDbContext(
            IMongoDatabase context,
            IOptions<BetDbConfig> options)
        {
            _context = context;
            _betDbConfig = options.Value;
        }

        public IMongoCollection<OutcomeGroupEntity> OutcomeGroupCollection
            => _context.GetCollection<OutcomeGroupEntity>(_betDbConfig.OutcomeGroupCollectionName);

        public IMongoCollection<BetEntitiy> BetCollection
            => _context.GetCollection<BetEntitiy>(_betDbConfig.BetCollectionName);

        public IMongoCollection<TeamEntity> TeamCollection
            => _context.GetCollection<TeamEntity>(_betDbConfig.TeamsCollectionName);

        public IMongoCollection<CompetitionDota2Entity> CompetitionCSCollection
            => _context.GetCollection<CompetitionDota2Entity>(_betDbConfig.CompetitionsCollectionName);
    }
}
