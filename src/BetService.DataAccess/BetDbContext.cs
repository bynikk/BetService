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

        public IMongoCollection<CompetitionDota2Entity> CompetitionDoat2Collection
            => _context.GetCollection<CompetitionDota2Entity>(_betDbConfig.CompetitionsCollectionName);
    }
}
