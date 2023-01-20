using AutoMapper;
using BetService.BusinessLogic.Contracts.Repositories;
using BetService.BusinessLogic.Models.Competitions;
using BetService.DataAccess.MongoEntities.CompetitionEntities;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace BetService.DataAccess.Repositories
{
    public class CompetitionDota2Repository : ICompetitionRepository<CompetitionDota2>
    {
        private readonly IMongoCollection<CompetitionDota2Entity> _collection;
        private readonly IMapper _mapper;
        private readonly ILogger<CompetitionDota2Repository> _logger;

        private static readonly InsertOneOptions _defaultInsertOneOption = new();
        private static readonly UpdateOptions _defaultUpdateOption = new();

        public CompetitionDota2Repository(
            IMongoCollection<CompetitionDota2Entity> collection,
            IMapper mapper,
            ILogger<CompetitionDota2Repository> logger)
        {
            _collection = collection;
            _mapper = mapper;
            _logger = logger;
        }

        public Task CreateCompetition(CompetitionDota2 item, CancellationToken cancellationToken)
        {
            var itemEntity = _mapper.Map<CompetitionDota2Entity>(item);

            return _collection.InsertOneAsync(itemEntity, _defaultInsertOneOption, cancellationToken);
        }

        public Task DeleteCompetitionById(Guid Id, CancellationToken cancellationToken)
        {
            var builder = Builders<CompetitionDota2Entity>.Filter;
            var quaryId = builder.Eq(x => x.Id, Id.ToString());

            return _collection.DeleteOneAsync(quaryId, cancellationToken);
        }

        public async Task UpdateCompetition(CompetitionDota2 item, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(item, nameof(item));

            var entity = _mapper.Map<CompetitionDota2Entity>(item);
            var builder = Builders<CompetitionDota2Entity>.Update;

            var updateId = builder.Set(x => x.Id, entity.Id);
            var updateName = builder.Set(x => x.StartTime, entity.StartTime);
            var updateTotalTime = builder.Set(x => x.TotalTime, entity.TotalTime);
            var updateTeam1Id = builder.Set(x => x.Team1Id, entity.Team1Id);
            var updateTeam2Id = builder.Set(x => x.Team2Id, entity.Team2Id);
            var updateTeam1KillAmount = builder.Set(x => x.Team1KillAmount, entity.Team1KillAmount);
            var updateTeam2KillAmount = builder.Set(x => x.Team2KillAmount, entity.Team2KillAmount);
            var updateType = builder.Set(x => x.Type, entity.Type);

            var update = builder.Combine(updateId,
                updateName,
                updateTotalTime,
                updateTeam1Id,
                updateTeam2Id,
                updateTeam1KillAmount,
                updateTeam2KillAmount,
                updateType);

            var filter = Builders<CompetitionDota2Entity>.Filter.Eq(x => x.Id, entity.Id);

            var result = await _collection.UpdateOneAsync(filter, update, _defaultUpdateOption, cancellationToken);

            if (result.IsAcknowledged)
            {
                _logger.LogTrace("Confirmed to update construction level with id={EntityId} in database.", item.Id);
            }
            else
            {
                _logger.LogTrace("Not confirmed to update construction level with id={EntityId} in database", item.Id);
            }

        }
    }
}
