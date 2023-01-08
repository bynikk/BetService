using BetService.DataAccess.MongoEntities;
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

        public IMongoCollection<BetEntitiy> Bets
            => _context.GetCollection<BetEntitiy>(_betDbConfig.BetsContainer);

        public IMongoCollection<BettorEntity> Bettors
            => _context.GetCollection<BettorEntity>(_betDbConfig.BettorsContainer);

        public IMongoCollection<TeamEntity> Teams
            => _context.GetCollection<TeamEntity>(_betDbConfig.TeamsContainer);

        public IMongoCollection<CompetitionEntity> Competitions
            => _context.GetCollection<CompetitionEntity>(_betDbConfig.CompetitionsContainer);

        public IMongoCollection<CoefficientEntity> Coefficients
            => _context.GetCollection<CoefficientEntity>(_betDbConfig.CoefficientsContainer);

        public IMongoCollection<OutcomeEntity> Outcomes
            => _context.GetCollection<OutcomeEntity>(_betDbConfig.OutcomesContainer);
    }
}
