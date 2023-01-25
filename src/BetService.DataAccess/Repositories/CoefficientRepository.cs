using AutoMapper;
using BetService.BusinessLogic.Contracts.Repositories;
using BetService.BusinessLogic.Models;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SharpCompress.Common;

namespace BetService.DataAccess.Repositories
{
    public class CoefficientRepository : ICoefficientRepository
    {
        private readonly IMongoCollection<CompetitionDota2Entity> _collection;
        private readonly IMapper _mapper;
        private readonly ILogger<CompetitionDota2Repository> _logger;

        private static readonly FindOneAndUpdateOptions<CompetitionDota2Entity> _defaultCompetitionDota2EntityFindOption = new();

        public CoefficientRepository(
            ILogger<CompetitionDota2Repository> logger,
            IMapper mapper,
            IMongoCollection<CompetitionDota2Entity> collection)
        {
            _logger = logger;
            _mapper = mapper;
            _collection = collection;
        }

        public async Task DepositAmountById(Guid competitionId, Guid сoefficientId, double amount, CancellationToken token)
        {
            var competitionIdstring = competitionId.ToString();
            var сoefficientIdstring = сoefficientId.ToString();

            var filterBuilder = Builders<CompetitionDota2Entity>.Filter;
            var updateBuilder = Builders<CompetitionDota2Entity>.Update;

            var filterCompetitionId = filterBuilder.Eq(x => x.Id, competitionId.ToString());

            var update = Builders<CompetitionDota2Entity>.Update;
                    var incAmount = update.Inc(x => x.CoefficientGroups.AllMatchingElements("cg")
                        .Coefficients.AllMatchingElements("c").Amount, amount);

            var _defaultCompetitionDota2EntityFindOption = new FindOneAndUpdateOptions<CompetitionDota2Entity>
            {
                ArrayFilters = new ArrayFilterDefinition[]
                {
                    new BsonDocumentArrayFilterDefinition<CoefficientGroup>
                    (
                        new BsonDocument("cg._id", competitionIdstring)
                    ),
                    new BsonDocumentArrayFilterDefinition<Coefficient>
                    (
                        new BsonDocument("c._id", сoefficientIdstring)
                    )
                }
            };

            var existingCoefficientGroup = await _collection.FindOneAndUpdateAsync(
                filterCompetitionId,
                incAmount,
                _defaultCompetitionDota2EntityFindOption,
                token);
        }
    }
}
